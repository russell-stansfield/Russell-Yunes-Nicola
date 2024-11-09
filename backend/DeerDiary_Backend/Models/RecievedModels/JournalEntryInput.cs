using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeerDiary_Backend.Models.RecievedModels
{
    public class JournalEntryInput
    {
        [Required(ErrorMessage = "Journal text missing")]
        public string? JournalText { get; set; }

        [Required(ErrorMessage = "Journal title missing")]
        public string? JournalTitle { get; set; }
    }
}
