using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DeerDiary_Backend.Models
{
    public class SignUpModel
    {
        [Required]
        public string _Username { get; set; }
        [Required]
        [EmailAddress]
        public string _Email { get; set; }
        [Required]
        public string _Password { get; set; }
    }
}
