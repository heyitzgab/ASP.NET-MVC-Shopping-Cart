using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ClothesLine.Models;

namespace ClothesLine.DB
{
    public class ClothesLineDbInitializer<T> :
        DropCreateDatabaseAlways<ClothesLineDbContext>

    {
        protected override void Seed(ClothesLineDbContext context)
        {        

            List<Category> cat = new List<Category>();
            cat.Add(new Product("T-Shirt", 10, 29.90, 0, "Uniqlo", "Shirt", "Silk"));            
            cat.Add(new Product("Pants", 10, 39.90, 0, "Uniqlo", "Pants", "Skinny"));           
            cat.Add(new Product("Shirt", 10, 29.90, 0, "Uniqlo", "Shirt", "Silk"));           
            cat.Add(new Product("10Pants", 10, 39.90, 0, "Uniqlo", "Shirt", "Silk"));

            foreach (Category categories in cat)
                context.Categories.Add(categories);
            context.SaveChanges();

            List<Customer> c = new List<Customer>();
            c.Add(new Customer("Kim", "Jong", "kimjong", "kimjong@gmail.com", 085678, "Clementi"));
            c.Add(new Customer("Gabriel", "Seah", "gabrielseah", "gabriel@gmail.com", 098765, "BukitTimah"));
            c.Add(new Customer("Kyi", "Phyu", "kyiphyu", "kyiphyu@gmail.com", 098765, "Common Wealth"));
            foreach (Customer customer in c)
            {
                context.Customers.Add(customer);
            }
            context.SaveChanges();

            // Console.ReadLine();

            base.Seed(context);
        }
    }
}
