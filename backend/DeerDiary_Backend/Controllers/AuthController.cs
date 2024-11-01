using DeerDiary_Backend.Data;
using DeerDiary_Backend.Models;
using DeerDiary_Backend.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Login([FromBody] User user) {

            if (_Context.Users.Where(x =>
                (x._username == user._username || x._usermail == user._usermail) &&
                x._userpassword == user._userpassword).FirstOrDefault() != null)
            {
                return Content(_Jwtmanager.GenerateJwtToken(user._username));
            }
            

            return Unauthorized();
        }
    }

}

