using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoption.Models
{
    public class Adoption
    {
        [Key] int id;
        
       int userId;
        int animalId;
        string date;

        public Adoption(int id, int userId, int animalId, string date)
        {
            Id = id;
            UserId = userId;
            AnimalId = animalId;
            Date = date;
        }

        public int Id { get => id; set => id = value; }
        public int UserId { get => userId; set => userId = value; }
        public int AnimalId { get => animalId; set => animalId = value; }
        public string Date { get => date; set => date = value; }
    }
}
