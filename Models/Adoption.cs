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
        int animalId;
        string animalName;
        string date ;
        int userId;
        string userName;
        string userSurname;
        string userAdress;
        string userProfession;
        string userFamily_situation;
         int userAge;
        string remarks;

        public Adoption(int id, int animalId, string animalName, string date, int userId, string userName, string userSurname, string userAdress, string userProfession, string userFamily_situation, int userAge, string remarks)
        {
            this.id = id;
            this.animalId = animalId;
            this.animalName = animalName;
            this.date = date;
            this.userId = userId;
            this.userName = userName;
            this.userSurname = userSurname;
            this.userAdress = userAdress;
            this.userProfession = userProfession;
            this.userFamily_situation = userFamily_situation;
            this.userAge = userAge;
            this.remarks = remarks;
        }

        public int Id { get => id; set => id = value; }
        public int AnimalId { get => animalId; set => animalId = value; }
        public string AnimalName { get => animalName; set => animalName = value; }
        public string Date { get => date; set => date = value; }
        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserSurname { get => userSurname; set => userSurname = value; }
        public string UserAdress { get => userAdress; set => userAdress = value; }
        public string UserProfession { get => userProfession; set => userProfession = value; }
        public string UserFamily_situation { get => userFamily_situation; set => userFamily_situation = value; }
        public int UserAge { get => userAge; set => userAge = value; }
        public string Remarks { get => remarks; set => remarks = value; }
    }
}
