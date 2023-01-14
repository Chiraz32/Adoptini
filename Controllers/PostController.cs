using AnimalAdoption.DB_Connection.Repositories;
using AnimalAdoption.DB_Connection;
using AnimalAdoption.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Http;

namespace AnimalAdoption.Controllers
{
    public class PostController : Controller
    {
        [HttpGet("post")]
        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString("userEmail");
            if (session == null)
                return Redirect("/signin");
            return View();
        }

        [HttpPost ("post")]
        public IActionResult Index(string name,string type,int age,int weight,
                                string adress, IFormFile image,string breed,string gender,string description )
        {

            Debug.WriteLine(" form arrived");
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            List<Animal> animals = dataBaseContext.animal.ToList();
            int id = animals.Count();
            string uniqueFileName="";
            if (image != null)
            {
                 uniqueFileName = GetUniqueFileName(image.FileName);

                var filePath = Path.Combine("wwwroot/images", uniqueFileName);
                image.CopyTo(new FileStream(filePath, FileMode.Create));

                //to do : Save uniqueFileName  to your db table   
            }

            List<User> users = DataBaseContext.dataBase_Context.user.ToList();
            var email = HttpContext.Session.GetString("userEmail");
            User user = users.Find(user => user.Email == email);
            Animal animal = new Animal(name,type,age,adress, uniqueFileName, breed,gender , weight ,++id ,email,description) ;

            AnimalRepository animalRepository = new AnimalRepository(dataBaseContext);
            animalRepository.Add(animal);


            return RedirectToAction("ViewAnimal", "Catalogue",new { id=id} );

        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    
        public IActionResult ModifyPost(int id)
        {
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            List<Animal> animals = dataBaseContext.animal.ToList();
            Animal animal = animals.Find(animal => animal.Id == id);
            
            var session = HttpContext.Session.GetString("userEmail");
            Debug.WriteLine("sesssion" +session);
            if (session == null)
                return Redirect("/signin");
            if ( session != animal.UserMail)
                {
                RedirectToAction("Index", "Catalogue", new { id = animal.Id });
                 }
               
            return View(animal);
        }

        public IActionResult Modifying(int id,string name, string type, int age, int weight,
                              string adress, IFormFile image, string breed, string gender, string description)
        {

            Debug.WriteLine(" form arrived");
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            List<Animal> animals = dataBaseContext.animal.ToList();
            Animal animal = animals.Find(animal => animal.Id == id);
            Debug.WriteLine("old animal" + animal.ToString());
            string uniqueFileName = "";
           
            if (image != null)
            {
              
                uniqueFileName = GetUniqueFileName(image.FileName);

                var filePath = Path.Combine("wwwroot/images", uniqueFileName);
                image.CopyTo(new FileStream(filePath, FileMode.Create));
               
                //to do : Save uniqueFileName  to your db table   
            }
            else
            {
                uniqueFileName= animal.Image;
            }

            List<User> users = DataBaseContext.dataBase_Context.user.ToList();
            var email = HttpContext.Session.GetString("userEmail");
            User user = users.Find(user => user.Email == email);
            
            AnimalRepository animalRepository = new AnimalRepository(dataBaseContext);
            animalRepository.Remove(animal);
            Animal newAnimal = new Animal(name, type, age, adress, uniqueFileName, breed, gender, weight, id, email, description);
            animalRepository.Add(newAnimal);

            return RedirectToAction("ViewAnimal", "Catalogue", new { id = animal.Id });

        }
    }
}
