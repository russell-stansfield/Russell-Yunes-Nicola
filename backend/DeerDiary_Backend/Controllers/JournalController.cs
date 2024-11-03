using DeerDiary_Backend.Data;
using DeerDiary_Backend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using ZstdSharp.Unsafe;

namespace DeerDiary_Backend.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    [Consumes("application/json")]
    public class JournalController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public JournalController(ApplicationDbContext context)
        {
            _Context = context;
        }

        // Return random question
        [HttpGet]
        public IActionResult RandomQuestion()
        {
            List<RandomQuestion> content = _Context.RandomQuestions.ToList();

            Random rand = new Random();

            return Content(content[rand.Next(0, content.Count - 1)].RandomQuestionText);
        }

        // Return all journal entries
        [HttpGet]
        public IActionResult AllEntries()
        {
            var accessToken = HttpContext.GetTokenAsync("Bearer", "access_token").Result;
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(accessToken) as JwtSecurityToken;
            string subject = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            List<JournalEntry> entries = _Context.JournalEntries.Where(u => u._user.UserName == subject).ToList();

            return Ok(entries);
        }

        [HttpGet]
        public IActionResult SpecificQuestion()
        {
                
                List<Reply> content = _Context.Replies.ToList();

                Random rand = new Random();

                return Ok(content[rand.Next(0, content.Count - 1)].ReplyText);
        }

        [HttpPost]
        public IActionResult SendResponse([FromBody] Reply response)
        {
            if (ModelState.IsValid)
            {
                _Context.Replies.Add(response);

                _Context.SaveChanges();

                return Ok();
            }

            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult PostJournalEntry([FromBody]JournalEntry entry)
        {
            if (ModelState.IsValid)
            {
                _Context.JournalEntries.Add(entry);

                _Context.SaveChanges();

                return Content(entry.JournalTitle);
            }

            return BadRequest(ModelState);
        }
    }
}
