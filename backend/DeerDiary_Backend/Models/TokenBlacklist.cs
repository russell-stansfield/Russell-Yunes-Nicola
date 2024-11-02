using System.ComponentModel.DataAnnotations.Schema;

namespace DeerDiary_Backend.Models
{
    public class TokenBlacklist
    {
        [Column("TokenId")]
        public int Id { get; set; }
        [Column("Token")]
        public string _token { get; set; }
        [Column("TokenExpiry")]
        public DateTime _expiry { get; set; }
    }
}
