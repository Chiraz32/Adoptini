using AnimalAdoption.DB_Connection;
using AnimalAdoption.DB_Connection.Repositories;
using AnimalAdoption.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace AnimalAdoption.Controllers
{
    public class AdoptingController : Controller
    {
        public IActionResult Adopt(int id )
        {
            Debug.WriteLine(" form loading");
           
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            List<Animal> animals = DataBaseContext.dataBase_Context.animal.ToList();
            Animal animal = new Animal();
            animal = animals.Find(animal =>animal.Id == id);
            Debug.WriteLine(animal.Name + animal.Id);
            Adoption adoption = new Adoption(id,animal.Name);
            return View(adoption);

        }
      
        [HttpPost]
        public ActionResult Adopt(int animalId,
        string animalName,
        string userName,
        string userSurname,
        int userPhone,
        string userEmail,
        string userAdress,
        string userProfession,
        string userFamily_situation,
        int userAge,
        string remarks)
        {
            
            Debug.WriteLine(" form arrived");
            Debug.WriteLine(animalId);
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();

            List<Adoption> adoptions = DataBaseContext.dataBase_Context.adoption.ToList();

            List<User> users = DataBaseContext.dataBase_Context.user.ToList();
            var email = HttpContext.Session.GetString("userId");
            User user = users.Find(user => user.Email == email);


            int id = adoptions.Count();
            Debug.WriteLine(" adoplist " + id);
            var date = DateTime.Now.ToString();
            Adoption adoption = new Adoption(id + 1, animalId, animalName, date, userName, userSurname,userPhone,userEmail, userAdress, userProfession, userFamily_situation, userAge, remarks);
            AdoptingRepository adoptingRepository = new AdoptingRepository(dataBaseContext);
            adoptingRepository.Add(adoption);
            IEnumerable<Adoption> adoptionsList = adoptingRepository.GetAll();
            Debug.WriteLine(" adoplist " + adoptionsList.Count());
            
            return RedirectToAction("Index","Catalogue",new { succmsg = " Your request is sent successfully" });
        }
    }
}
