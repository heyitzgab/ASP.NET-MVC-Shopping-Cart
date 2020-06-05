using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClothesLine.Models;

namespace ClothesLine.DB
{
    public class ClothesLineDbContext:DbContext
    {
        public ClothesLineDbContext() : base("Server=DESKTOP-FFOPRP5;" + "Database = ClothesLine; Integrated Security = True;")
        {
          Database.SetInitializer(new ClothesLineDbInitializer<ClothesLineDbContext>());
           // Database.Connection
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }       
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

           }
   
   
}