using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Journal date missing")]
        public string? JournalDate { get; set; }
        [Column("JournalText")]
        [Required(ErrorMessage = "Journal text missing")]
        public string? JournalText { get; set; }

        [Column("JournalTitle")]
        [Required(ErrorMessage = "Journal title missing")]
        public string? JournalTitle { get; set; }

        [Column("fk_RandomQuestionId")]
        [JsonPropertyName("fk_RandomQuestionId")]
        public int? _RandomQuestionId { get; set; }
        public RandomQuestion? _randomquestion { get; set; }

        [Column("fk_UserId")]
        [JsonPropertyName("fk_UserId")]
        [Required(ErrorMessage = "Relation to user missing")]
        public int _userid { get; set; }
        public User _user { get; set; }
    }
}
