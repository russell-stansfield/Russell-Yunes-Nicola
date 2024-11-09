using DeerDiary_Backend.Data;
using DeerDiary_Backend.Models;
using DeerDiary_Backend.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeerDiary_Backend.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;

        private readonly JWTManager _Jwtmanager;

        public AuthController(ApplicationDbContext context, JWTManager jwtmanager)
        {
            _Context = context;
            _Jwtmanager = jwtmanager;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserInput user) {

            if (ModelState.IsValid)
            {
                var DBuser = _Context.Users.SingleOrDefault(x => x.UserName == user.UserName);

                if (user is null) return Unauthorized();

                if (PasswordHasher.VerifyPassword(user.UserPassword, DBuser.UserPassword, DBuser.PasswordSalt))
                {
                    return Content(_Jwtmanager.GenerateJwtToken(user.UserName));
                }
            }
            return BadRequest();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Logout()
        {

            var accessToken = HttpContext.GetTokenAsync("Bearer", "access_token").Result;

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(accessToken) as JwtSecurityToken;
            var expiry = jwtToken.ValidTo;

            _Context.TokenBlacklists.Add(new TokenBlacklist
            {
                Token = accessToken.ToString(),
                TokenExpiry = expiry
            });
            _Context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserInput user)
        {
            if (ModelState.IsValid)
            {
                if (_Context.Users.Where(x => x.UserName == user.UserName ).FirstOrDefault() != null) return Conflict("Username already exists");
                else if (_Context.Users.Where(x => x.UserMail == user.UserMail).FirstOrDefault() != null) return Conflict("Account already exists");

                string salt;
                string hashedPassword = PasswordHasher.HashPassword(user.UserPassword, out salt);

                User Instance = new User()
                {
                    UserName = user.UserName,
                    UserMail = user.UserMail
                };

                Instance.UserPassword = hashedPassword;
                Instance.PasswordSalt = salt;

                _Context.Users.Add(Instance);
                _Context.SaveChanges();

                return Ok();

            }

            return BadRequest(ModelState);
        }
    }

}

