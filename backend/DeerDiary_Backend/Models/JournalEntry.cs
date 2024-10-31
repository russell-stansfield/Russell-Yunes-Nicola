using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeerDiary_Backend.Models
{
    public class JournalEntry
    {
        [Column("JournalId")]
        [JsonPropertyName("JournalId")]
        public int Id { get; set; }
        [Column("JournalDate")]
        [JsonPropertyName("JournalDate")]

        public string? _date { get; set; }
        [Column("JournalText")]
        [JsonPropertyName("JournalText")]

        public string? _text { get; set; }

        [Column("JournalTitle")]
        [JsonPropertyName("JournalTitle")]

        public string? _title { get; set; }

        [Column("RandomQuestionId")]
        [JsonPropertyName("RandomQuestionId")]
        public int _randomquestionid { get; set; }
        public RandomQuestion _randomquestion { get; set; }

        [Column("UserId")]
        [JsonPropertyName("UserId")]
        public int _userid { get; set; }
        public User _user { get; set; }
    }
}
