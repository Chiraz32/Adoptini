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
            return View();
        }

        [HttpPost ("post")]
        public IActionResult Index(string name,string type,int age,int weight,
                                string adress, IFormFile image,string breed,string gender)
        {

            Debug.WriteLine(" form arrived");
            DataBaseContext dataBaseContext = DataBaseContext.Instantiate_DataBaseContext();
            List<Animal> animals = dataBaseContext.animal.ToList();
            int id = animals.Count();
            string uniqueFileName="";
            if (image != null)
            {
                 uniqueFileName = GetUniqueFileName(image.FileName);

                var filePath = Path.Combine("images", uniqueFileName);
                image.CopyTo(new FileStream(filePath, FileMode.Create));

                //to do : Save uniqueFileName  to your db table   
            }

            Animal animal = new Animal(name,type,age,adress, uniqueFileName, breed,gender , weight ,++id ) ;
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
    }
}
