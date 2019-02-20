using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLC.Models
{
    public class LoginModel
    {

        private string username;
        private string password;

        public LoginModel() { }

        [DisplayName("Username")]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public string Username { get => username; set => username = value; }
        [DisplayName("Password")]
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [DefaultValue("")]
        public string Password { get => password; set => password = value; }
    }
}