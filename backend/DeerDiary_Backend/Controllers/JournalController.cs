using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeerDiary_Backend.Controllers
{
    public class JournalController : Controller
    {
        // Return random question
        public ContentResult GetRandomQuestion()
        {
            return Content("message", "text/plain");
        }

        // Return all journal entries
        public ContentResult GetAllEntries()
        {
            return Content("message", "text/plain");
        }

        // Return response to entry
        public ContentResult GetSpecificQuestion()
        {
            return Content("message", "text/plain");
        }

        // Receive response to specific question
        public ContentResult PostResponseQuestion()
        {
            return Content("message", "text/plain");
        }

        // Receive journal entry
        public ContentResult PostJournalEntry()
        {
            return Content("message", "text/plain");
        }

        // Change settings
        public ContentResult PutSettings()
        {
            return Content("message", "text/plain");
        }
    }
}
