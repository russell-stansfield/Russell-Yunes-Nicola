using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeerDiary_Backend.Models
{
    public class Reply
    {
        [Column("ReplyId")]
        public int ReplyId { get; set; }
        [Column("ReplyText")]
        [Required(ErrorMessage = "Reply text missing")]
        public string ReplyText { get; set; }
        [Column("ReplyGeneratedQuestion")]
        [Required(ErrorMessage = "Reply generated question missing")]
        public string ReplyGeneratedQuestion { get; set; }

        [Column("fk_JournalEntryId")]
        [Required(ErrorMessage = "Relation to JournalEntry missing")]
        public int _JournalEntryId { get; set; }
        public JournalEntry _journalentry { get; set; }
    }
}
