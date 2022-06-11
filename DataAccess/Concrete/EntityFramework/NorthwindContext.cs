 using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını baglamak
    public class NorthwindContext:DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//Proje hangi veritabanı ile ilişkili olduğunu belirteceğimiz yer.
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;DataBase=Northwind;Trusted_Connection=True");

        }
        //Veritabanı ile classlarımızı ilişkilendiriyoruz.
        public DbSet<Product> Products { get; set; } // Dbde ki ;Products tablosunu simgeliyor.
        public DbSet<Category> Categories { get; set; } // Dbde ki ;Categories tablosunu simgeliyor.
        public DbSet<Customer> Customers { get; set; } // Dbde ki ;Customers tablosunu simgeliyor.
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
