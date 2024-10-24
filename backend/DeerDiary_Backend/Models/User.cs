using System.ComponentModel.DataAnnotations.Schema;

namespace DeerDiary_Backend.Models
{
    public class User
    {
        [Column("UserId")]
        public int Id { get; set; }
        [Column("UserName")]
        public string _username { get; set; }
        [Column("UserPassword")]
        public string _userpassword { get; set; }
        [Column("JournalId")]
        public string _usermail { get; set; }
    }
}
