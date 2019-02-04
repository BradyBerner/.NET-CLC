using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLC.Models
{
    public class LoginModel
    {

        private string username;
        private string password;

        public LoginModel() { }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}