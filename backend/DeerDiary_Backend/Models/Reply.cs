using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeerDiary_Backend.Models
{
    public class Reply
    {
        [Column("ReplyId")]
        [JsonPropertyName("ReplyId")]
        public int Id { get; set; }
        [Column("ReplyText")]
        [JsonPropertyName("ReplyText")]
        public string _text { get; set; }
        [Column("ReplyGeneratedQuestion")]
        [JsonPropertyName("ReplyGeneratedQuestion")]
        public string _generatedquestion { get; set; }

        [Column("fk_JournalEntryId")]
        [JsonPropertyName("fk_JournalEntryId")]
        public int _journalentryid { get; set; }
        public JournalEntry _journalentry { get; set; }
    }
}
