﻿using Org.BouncyCastle.Asn1.Cmp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DeerDiary_Backend.Models
{
    [DataContract]
    public class User
    {
        [Column("UserId")]
        public int? Id { get; set; }
        [Column("UserName")]
        [Required(ErrorMessage = "User name missing")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User password missing")]
        [Column("UserPassword")]
        public string UserPassword { get; set; }
        [EmailAddress (ErrorMessage = "Invalid E-Mail format")]
        [Column("UserMail")]
        public string UserMail { get; set; }
        [Column("PasswordSalt")]
        public string PasswordSalt { get; set; }
    }
}
