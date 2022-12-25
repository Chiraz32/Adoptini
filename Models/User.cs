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
        string name;
        string surname;
        string email;
        string adress;
        string profession;
        string family_situation;
         int age;
        string phone_number;

        public User(int id, string name, string surname, string email, string adress, string profession, string family_situation, int age, string phone_number)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Adress = adress;
            Profession = profession;
            Family_situation = family_situation;
            Age = age;
            Phone_number = phone_number;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Email { get => email; set => email = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Profession { get => profession; set => profession = value; }
        public string Family_situation { get => family_situation; set => family_situation = value; }
        public int Age { get => age; set => age = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }

        public override string ToString()
        {
            return this.Name+ " 'profession is  "+this.Profession;
        }
    }
}
