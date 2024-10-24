using System.ComponentModel.DataAnnotations.Schema;

namespace DeerDiary_Backend.Models
{
    public class JournalEntries
    {
        [Column("JournalEntryId")]
        public int? Id { get; set; }
        [Column("JournalDate")]
        public string? Date { get; set; }
        [Column("JournalText")]
        public string? Text { get; set; }
    }
}
