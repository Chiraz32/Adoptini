using AnimalAdoption.DB_Connection;
using System.Collections.Generic;
using System.Diagnostics;
using AnimalAdoption.DB_Connection.Repositories;
using AnimalAdoption.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace AnimalAdoption.Controllers
{
    public class UserAuthController : Controller
    {
        public IActionResult SignIn(string? errorMessage)
        {
            ViewBag.errorMessage = errorMessage;
            return View();
        }
        public IActionResult SignUp(string? errorMessage)
        {
            ViewBag.errorMessage = errorMessage;
            return View();
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/home");
        }
        [HttpPost]
        public IActionResult CreateUser(string email, string password, string phone_number)
        {
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            List<User> users = DataBaseContext.dataBase_Context.user.ToList();
            int id = users.Count();
            User user = new User(id + 1, email, password, phone_number);
            UserRepository userRepository = new UserRepository(dataBaseContext);
            if (userRepository.Find(user => user.Email == email).Count() != 0)
            {
                string errorMessage = "A user with the specified email already exists";
                return RedirectToAction("SignUp", new { errorMessage = errorMessage });
            }
            userRepository.Add(user);
            IEnumerable<User> usersList = userRepository.GetAll();
            Debug.WriteLine(" userlist " + usersList.Count());
            return Redirect("/SignIn");
        }

        public IActionResult AuthenticateUser(string email, string password)
        {
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            UserRepository userRepository = new UserRepository(dataBaseContext);


            if (userRepository.Find(user => user.Email == email).Count() == 0)
            {
                string errorMessage = "Cannot find user with the specified email";
                return RedirectToAction("SignIn", new {errorMessage = errorMessage});
            }
            User user = userRepository.Find(user => user.Email == email)?.ElementAt(0);
            if (user.Password != password)
            {
                Debug.WriteLine("please verify password");
                string errorMessage = "please verify password";
                return RedirectToAction("SignIn", new { errorMessage = errorMessage });
            }
            HttpContext.Session.SetString("userEmail",email);
            HttpContext.Session.SetInt32("userId", user.Id);
            return Redirect("/");

        }
        public IActionResult DeleteUser(int id)
        {
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            UserRepository userRepository = new UserRepository(dataBaseContext);
            AnimalRepository animalRepository = new AnimalRepository(dataBaseContext);
            User user = userRepository.Get(id);
            if (user!=null)
            {
                IEnumerable<Animal> userAnimals = animalRepository.Find(animal => animal.UserMail == user.Email);
                animalRepository.RemoveRange(userAnimals);
                userRepository.Remove(user);
                HttpContext.Session.Clear();
               
            }
            return Redirect("/");
        }
    }
}
