using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeerDiary_Frontend.Models
{
    public class TokenBlacklist
    {
        [Column("TokenId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Token content missing")]
        [Column("Token")]
        public string Token { get; set; }
        [Required(ErrorMessage = "Token expiry missing")]
        [Column("TokenExpiry")]
        public DateTime TokenExpiry { get; set; }
    }
}
