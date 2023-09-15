using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScadaSnusProject.Model
{
    public class User

    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string name, string surname, string username, string password)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
        }
    }
}