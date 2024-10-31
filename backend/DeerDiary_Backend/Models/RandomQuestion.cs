using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeerDiary_Backend.Models
{
    public class RandomQuestion
    {
        [Column("RandomQuestionId")]
        [JsonPropertyName("RandomQuestionId")]

        public int Id { get; set; }
        [Column("RandomQuestionText")]
        [JsonPropertyName("RandomQuestionText")]

        public string _text { get; set; }

    }
}
