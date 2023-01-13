using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoption.Models
{
    public class Animal
    {
        [Key] int id;
        string name;
        string type;
        int age;
        int weight;
        string adress;
        string image;
        string breed;
        string gender;
        string userMail;

        public Animal()
        {
        }

        public Animal(string name, string type, int age, string adress, string image, string breed, string gender, int weight, int id,string userMail)
        {
            Name = name;
            Type = type;
            Age = age;
            Adress = adress;
            Image = image;
            Breed = breed;
            Gender = gender;
            Id = id;
            Weight = weight;
            UserMail = userMail;
        }

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public int Age { get => age; set => age = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Image { get => image; set => image = value; }
        public string Breed { get => breed; set => breed = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Id { get => id; set => id = value; }
        public int Weight { get => weight; set => weight = value; }
        public string UserMail { get => userMail; set => userMail = value; }
    }


}
