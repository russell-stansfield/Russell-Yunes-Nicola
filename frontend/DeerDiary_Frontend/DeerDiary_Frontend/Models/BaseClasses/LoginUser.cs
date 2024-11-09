using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DeerDiary_Frontend.Models.BaseClasses
{

    public class LoginUser
    {

        [Column("UserName")]
        [Required(ErrorMessage = "User name missing")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User password missing")]
        [Column("UserPassword")]
        public string UserPassword { get; set; }
    }
}
