using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeerDiary_Frontend.Models
{
    public class Reply
    {

        [Column("ReplyText")]
        [Required(ErrorMessage = "Reply text missing")]
        public string ReplyText { get; set; }
        [Column("ReplyGeneratedQuestion")]
        [Required(ErrorMessage = "Reply generated question missing")]
        public string ReplyGeneratedQuestion { get; set; }
    }
}
