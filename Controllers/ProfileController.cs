using AnimalAdoption.DB_Connection.Repositories;
using AnimalAdoption.DB_Connection;
using AnimalAdoption.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;
using System.Linq;

namespace AnimalAdoption.Controllers
{
    public class ProfileController : Controller
    {
        // GET: UserController
        DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();

        [HttpGet("/profile")]
        public IActionResult Index()
        {
            UserRepository userRepository = new UserRepository(dataBaseContext);
            AnimalRepository animalRepository = new AnimalRepository(dataBaseContext);


            List<User> users = DataBaseContext.dataBase_Context.user.ToList();
            var email = HttpContext.Session.GetString("userEmail");
            User user = users.Find(user => user.Email == email);

             IEnumerable<Animal> animalsForAdoption  = animalRepository.Find(animal => animal.UserMail == email);

            ViewBag.user = user;
            ViewBag.animalsForAdoption = animalsForAdoption ;
            ViewBag.postNumber = animalsForAdoption.Count();
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult DeletePost(int id)
        {
            AnimalRepository animalRepository = new AnimalRepository(dataBaseContext);
            Animal animal = animalRepository.Get(id);
            animalRepository.Remove(animal);
            
            return Redirect("/profile");
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
