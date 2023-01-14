using AnimalAdoption.DB_Connection;
using AnimalAdoption.DB_Connection.Repositories;
using AnimalAdoption.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoption.Controllers
{
    public class CatalogueController : Controller
    {
        DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
        private readonly ILogger<CatalogueController> _logger;

        public CatalogueController(ILogger<CatalogueController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index(string? succmsg)
        {
            List<Animal> animals = dataBaseContext.animal.ToList();
            ViewBag.animals = animals;
            ViewBag.error= succmsg;
            return View();
        }

        [HttpGet("/animal/{id}")]
        public IActionResult ViewAnimal(int id)
        {
            AnimalRepository animalRepository = new AnimalRepository (dataBaseContext);
            Animal animal = animalRepository.Get(id);
            ViewBag.animal = animal;


            List<User> users = DataBaseContext.dataBase_Context.user.ToList();
            var email = HttpContext.Session.GetString("userEmail");

            if (email == animal.UserMail) ViewBag.user = true; 


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("/test")]
        public IActionResult Test ()
        {
            return View();

        }
    }
}
