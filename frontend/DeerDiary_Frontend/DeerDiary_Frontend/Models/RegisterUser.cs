using DeerDiary_Frontend.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DeerDiary_Frontend.Models
{
    public class RegisterUser: LoginUser
    {
        [EmailAddress(ErrorMessage = "Invalid E-Mail format")]
        [Column("UserMail")]
        [Required(ErrorMessage = "User mail missing")]
        public string? UserMail { get; set; }
    }
}
