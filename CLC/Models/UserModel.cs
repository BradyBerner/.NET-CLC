using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DefaultValue(-1)]
        public int Id { get => id; set => id = value; }
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
        [DisplayName("First Name")]
        [Required]
        [StringLength(10, MinimumLength = 3)]
        [DefaultValue("")]
        public string Firstname { get => firstname; set => firstname = value; }
        [DisplayName("Last Name")]
        [Required]
        [StringLength(10, MinimumLength = 3)]
        [DefaultValue("")]
        public string Lastname { get => lastname; set => lastname = value; }
        [DisplayName("Sex")]
        [Required]
        [DefaultValue("")]
        public char Sex { get => sex; set => sex = value; }
        [DisplayName("Age")]
        [Required]
        [DefaultValue(0)]
        public int Age { get => age; set => age = value; }
        [DisplayName("State")]
        [Required]
        [StringLength(15, MinimumLength = 5)]
        [DefaultValue("")]
        public string State { get => state; set => state = value; }
        [DisplayName("Email")]
        [Required]
        [DefaultValue("")]
        public string Email { get => email; set => email = value; }
        [DefaultValue(0)]
        public int Role { get => role; set => role = value; }
    }
}