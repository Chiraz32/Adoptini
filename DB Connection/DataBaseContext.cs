using AnimalAdoption.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoption.DB_Connection
{
    public class DataBaseContext :Microsoft.EntityFrameworkCore.DbContext
    {
    private static DataBaseContext dataBaseContext = null;
    private DataBaseContext(DbContextOptions o) : base(o) { }

    public DbSet<Animal> animal { get; set; }
    public DbSet<User> user { get; set; }
    public DbSet<Adoption> adoptions { get; set; }
    public static DataBaseContext dataBase_Context { get => dataBaseContext; set => dataBaseContext = Instantiate_DataBaseContext(); }

    public static DataBaseContext Instantiate_DataBaseContext()
    {
        if (dataBaseContext == null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsBuilder.UseSqlite(@"Data Source=../project.db");
            
                dataBaseContext = new DataBaseContext(optionsBuilder.Options);
            return dataBaseContext;
        }
           

        return dataBaseContext;
    }



}
}
