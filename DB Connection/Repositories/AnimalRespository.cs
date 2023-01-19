using AnimalAdoption.Models;
using Microsoft.VisualBasic.FileIO;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace AnimalAdoption.DB_Connection.Repositories
{
    public class AnimalRepository : Repository<Animal>
    {
        private readonly DataBaseContext _dataBaseContext;
        public AnimalRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
        {
            this._dataBaseContext = dataBaseContext;
        }
        
    public IEnumerable<Animal> filter ( List<string> filterList)
        {

            if (filterList.Count <1)
            {
                return this.GetAll();
            }
            IEnumerable<Animal> a = _dataBaseContext.Set<Animal>();




            if (filterList[0] != "null")
                a = a.Where(m => filterList[0].Contains(m.Type));
            if(filterList[1] != "null")
                a=a.Where ( m => filterList[1].Contains(m.Gender ) ) ;

            if (filterList[2] != "null")
            {
                int min1=0, min2=0, min3 = 0,max2 = 0,max3 = 0,max1=0;
                
                if (filterList[2].Contains('7'))
                {
                    min1 = 0; max1 = 12;
                }

                if (filterList[2].Contains("8"))
                { min2 = 12; max2 = 60; }

                if (filterList[2].Contains("9"))
                { min3 = 60; max3 = 6000; }

                a = a.Where(m => m.Age >= min1 && m.Age < max1 || m.Age >= min2 && m.Age < max2 || m.Age >= min3 && m.Age < max3 );


            }

            return a;

        }

    }
}
