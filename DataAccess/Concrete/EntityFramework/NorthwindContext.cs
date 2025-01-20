using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext // DbContext entity framework sql server paketi ile gelen sınıftır
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // bu metod proje hangi veri tabanı ile ilişkili olduğunu belirttiğimiz yerdir
        {
            optionsBuilder.UseSqlServer(@"Server=MSI;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;"); // Burada context hangi veri tabanına baglanacagini buldu asagida ise veri tabanı tablosuna karşılık proje icindeki class ları iliskilendirecegiz
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
