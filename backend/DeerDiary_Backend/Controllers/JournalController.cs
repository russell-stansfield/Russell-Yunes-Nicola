using DeerDiary_Backend.Data;
using DeerDiary_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeerDiary_Backend.Controllers
{
    [Route("[controller]/[action]")]
    //[Authorize]
    public class JournalController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public JournalController(ApplicationDbContext context)
        {
            _Context = context;
        }

        // Return random question
        public ContentResult RandomQuestion()
        {
            string content = _Context.JournalEntries.FirstOrDefault()._text;

            return Content(content);
        }

        // Return all journal entries
        public ContentResult AllEntries()
        {
            return Content("message", "text/plain");
        }

        // Return response to entry
        public ContentResult SpecificQuestion()
        {
            return Content("message", "text/plain");
        }




        // Recieve

        // Receive response to specific question
        public ContentResult SendResponse(string response)
        {

            return new ContentResult { StatusCode = 200 };
        }

        // Receive journal entry
        public ContentResult PostJournalEntry(JournalEntry entry)
        {



            return new ContentResult { StatusCode = 200 };
        }
    }
}
