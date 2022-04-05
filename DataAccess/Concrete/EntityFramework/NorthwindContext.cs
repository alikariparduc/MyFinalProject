using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını baglamak
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Proje hangi veritabanı ile ilişkili olduğunu belirteceğimiz yer.
        {
            optionsBuilder.UseSqlServer(@"Server=Ali;DataBase=Northwind;Trusted_Connection=True");

        }
        //Veritabanı ile classlarımızı ilişkilendiriyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
