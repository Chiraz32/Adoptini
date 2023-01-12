using AnimalAdoption.DB_Connection;
using AnimalAdoption.DB_Connection.Repositories;
using AnimalAdoption.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoption.Controllers
{
    public class AdoptingController : Controller
    {
        public IActionResult Adopt()
        {
            Debug.WriteLine(" form loading");
            return View();
        }
        public IActionResult Afficher()
        {
            Debug.WriteLine("in afficher " );
         
            return View();
        }



        [HttpPost]
        public ActionResult Adopt(int animalId,
        string animalName,
        
        int userId,
        string userName,
        string userSurname,
        string userAdress,
        string userProfession,
        string userFamily_situation,
        int userAge,
        string remarks)
        {
            Debug.WriteLine(" form arrived");
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            List<Adoption> adoptions= DataBaseContext.dataBase_Context.adoption.ToList();
            int id = adoptions.Count();
            Debug.WriteLine(" adoplist " + id);

            var date = DateTime.Now.ToString();
            
            Adoption adoption = new Adoption(id+1, animalId,animalName,
       date,
      userId,
         userName,
       userSurname,
  userAdress,
         userProfession,
        userFamily_situation,
         userAge,
         remarks);
          
            AdoptingRepository adoptingRepository = new AdoptingRepository(dataBaseContext);
            adoptingRepository.Add(adoption);
            IEnumerable<Adoption> adoptionsList = adoptingRepository.GetAll();
            Debug.WriteLine(" adoplist " +adoptionsList.Count());

            return RedirectToAction("Afficher");
        }
    }
}
