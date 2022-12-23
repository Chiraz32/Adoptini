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
        public ActionResult Adopt( string name ,string surname, string email,string adress,string profession, string family_situation,int age,string phone_number)
        {
            Debug.WriteLine(" form arrived");
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            List<User> users = DataBaseContext.dataBase_Context.user.ToList();
            int id = users.Count();
            
            User user = new User(id+1, name, surname, email, adress, profession, family_situation, age, phone_number);
            Debug.WriteLine("user added  "+ user.Name + user.Id+ user.Family_situation);
            UserRepository userRepository = new UserRepository(dataBaseContext);
            userRepository.Add(user);
            IEnumerable<User> usersList = userRepository.GetAll();
            Debug.WriteLine(" userlist " +usersList.Count());

            return RedirectToAction("Afficher");
        }
    }
}
