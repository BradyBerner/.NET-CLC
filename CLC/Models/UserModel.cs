using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLC.Models
{
    public class UserModel
    {
        private int id;
        private string username;
        private string password;
        private string firstname;
        private string lastname;
        private char sex;
        private int age;
        private string state;
        private string email;
        private int role;

        public UserModel() { }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public char Sex { get => sex; set => sex = value; }
        public int Age { get => age; set => age = value; }
        public string State { get => state; set => state = value; }
        public string Email { get => email; set => email = value; }
        public int Role { get => role; set => role = value; }
    }
}