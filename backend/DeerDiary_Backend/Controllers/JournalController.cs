using DeerDiary_Backend.Data;
using DeerDiary_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZstdSharp.Unsafe;

namespace DeerDiary_Backend.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class JournalController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public JournalController(ApplicationDbContext context)
        {
            _Context = context;
        }

        // Return random question
        [HttpGet]
        public ContentResult RandomQuestion()
        {
            List<RandomQuestion> content = _Context.RandomQuestions.ToList();

            Random rand = new Random();

            return Content(content[rand.Next(0, content.Count - 1)]._text);
        }

        // Return all journal entries
        [HttpGet]
        public IActionResult AllEntries()
        {

            List<JournalEntry> entries = _Context.JournalEntries.Where(u => u._user._username == "Alice" && u._user._userpassword == "password123").ToList();

            return Ok(entries);
        }

        // Return response to entry
        [HttpGet]
        public IActionResult SpecificQuestion()
        {
                
                List<Reply> content = _Context.Replies.ToList();

                Random rand = new Random();

                return Ok(content[rand.Next(0, content.Count - 1)]._text);
        }

        [HttpPost]
        public ContentResult SendResponse([FromBody] Reply response)
        {
            _Context.Replies.Add(response);

            _Context.SaveChanges();

            return new ContentResult { StatusCode = 200 };
        }
        [HttpPost]
        public ContentResult PostJournalEntry([FromBody]JournalEntry entry)
        {

            _Context.JournalEntries.Add(entry);

            _Context.SaveChanges();

            return Content(entry._title);
        }
    }
}
