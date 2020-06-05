using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesLine.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
      
        public Category()
        {

        }
        public Category(string CategoryName, string Description)
        {
            this.CategoryName = CategoryName;
            this.Description = Description;
        }
       
    }
}