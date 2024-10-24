using System.ComponentModel.DataAnnotations.Schema;

namespace DeerDiary_Backend.Models
{
    public class RandomQuestion
    {
        [Column("RandomQuestionId")]
        public int Id { get; set; }
        [Column("RandomQuestionText")]
        public string _text { get; set; }
    }
}
