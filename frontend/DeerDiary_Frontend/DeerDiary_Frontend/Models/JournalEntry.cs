using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeerDiary_Frontend.Models
{
    public class JournalEntry
    {
        [Column("JournalText")]
        [Required(ErrorMessage = "Journal text missing test")]
        public string JournalText { get; set; }

        [Column("JournalTitle")]
        [Required(ErrorMessage = "Journal title missing")]
        public string JournalTitle { get; set; }
    }
}
