using System.ComponentModel.DataAnnotations.Schema;

namespace DeerDiary_Backend.Models
{
    public class JournalEntry
    {
        [Column("JournalId")]
        public int Id { get; set; }
        [Column("JournalDate")]
        public string? _date { get; set; }
        [Column("JournalText")]
        public string? _text { get; set; }

        [Column("JournalTitle")]
        public string? _title { get; set; }
    }
}
