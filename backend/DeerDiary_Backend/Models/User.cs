using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DeerDiary_Backend.Models
{
    public class User
    {
        [Column("UserId")]
        [JsonPropertyName("UserId")]

        public int Id { get; set; }
        [Column("UserName")]
        [JsonPropertyName("UserName")]

        public string _username { get; set; }
        [Column("UserPassword")]
        [JsonPropertyName("UserPassword")]

        public string _userpassword { get; set; }
        [Column("UserMail")]
        [JsonPropertyName("UserMail")]

        public string _usermail { get; set; }
    }
}
