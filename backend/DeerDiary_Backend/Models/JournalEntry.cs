using System.ComponentModel.DataAnnotations.Schema;

namespace DeerDiary_Backend.Models
{
    [Table("JournalEntries")]
    public class JournalEntry
    {
        [Column("JournalId")]
        public int? Id { get; set; }
        [Column("JournalDate")]
        public string Date { get; set; }
        [Column("JournalText")]
        public string Text { get; set; }
    }
}
