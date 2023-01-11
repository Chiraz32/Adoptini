using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoption.Models
{
    public class User
    {
        [Key] int id;
        string email;
        string password;
        string phone_number;

        public User(int id, string email, string password, string phone_number)
        {
            id = id;
            Email = email;
            Password = password; 
            Phone_number = phone_number;
        }
        public int Id { get => id; set => id = value; } 
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }

    }
}
