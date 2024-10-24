using System.ComponentModel.DataAnnotations.Schema;

namespace DeerDiary_Backend.Models
{
    public class Reply
    {
        [Column("ReplyId")]
        public int Id { get; set; }
        [Column("ReplyText")]
        public string _text { get; set; }
        [Column("ReplyGeneratedQuestion")]
        public string _generatedquestion { get; set; }
    }
}
