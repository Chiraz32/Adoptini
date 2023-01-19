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
using System.Text;
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

        public IActionResult Index(string? succmsg, List<String>? selected)
        {
            AnimalRepository animalRepository = new AnimalRepository(dataBaseContext);
            List<checkboxfilter> filter1 = new List<checkboxfilter>()
                {  new checkboxfilter {Id= 1, Value="Dog", IsChecked  =false} ,
                   new checkboxfilter { Id = 2, Value = "Cat", IsChecked = false } ,
                   new checkboxfilter { Id = 3, Value = "Horse", IsChecked = false }
                };

            FilterForm type = new FilterForm { checkboxfilters = filter1, Label = "Type" };

            List<checkboxfilter> filter2 = new List<checkboxfilter>()
            { new checkboxfilter{Id=4, Value="Male", IsChecked= false } ,
              new checkboxfilter{Id=5, Value="Female",IsChecked= false }
            };

            FilterForm gender = new FilterForm { checkboxfilters = filter2, Label = "Gender" };


            List<checkboxfilter> filter3 = new List<checkboxfilter>(){
             new checkboxfilter{ Id=7, Value="0-12 Months",IsChecked = false } ,
             new checkboxfilter{Id=8, Value="2-5 Years",IsChecked= false },
             new checkboxfilter{Id=9,Value =">5 Years",IsChecked= false }
             };
            FilterForm age = new FilterForm { checkboxfilters = filter3, Label = "Age" };

            List<FilterForm> filters = new List<FilterForm>();
            filters.Add(type);
            filters.Add(gender);
            filters.Add(age);

            Form filterForm = new Form();
            filterForm.form = filters;

            IEnumerable<Animal> animals = animalRepository.filter(selected);

            
            ViewBag.animals = animals;
            ViewBag.error= succmsg;
            ViewBag.filterForm = filterForm;

            ViewBag.selected = selected;
                     
            return View(filterForm);
        }

        [HttpPost]
        public ActionResult Index(Form Obj)
        {
            string type ="null";
            bool ok = false;

            foreach( var item in  Obj.form[0].checkboxfilters)
            {
                if(item.IsChecked == true)
                {
                    if (ok == false)
                     { type = ""; ok = true; }
                    
                    type = type + item.Value + ',';

                }
            }

            String gender = "null";
            ok = false;

            foreach (var item in Obj.form[1].checkboxfilters)
            {
                if (item.IsChecked == true)
                {
                    if (ok == false)
                    { gender = ""; ok = true;  }
                   
                    gender = gender + item.Value + ',';

                }
            }

            String age = "null";
            ok = false;
           
            foreach (var item in Obj.form[2].checkboxfilters)
            {
                if (item.IsChecked == true)
                {
                    if (ok == false)
                        { age = ""; ok = true; }
                  
                    age = age + item.Id.ToString() + ',';

                }
            }

            List<String> s = new List<string>();
          
            s.Add(type.ToString().ToLower());
            s.Add(gender.ToString().ToLower());
            s.Add(age.ToString());

            return RedirectToAction("Index", new { selected = s });

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
