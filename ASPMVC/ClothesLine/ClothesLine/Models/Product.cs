using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesLine.Models
{
    public class Product: Category
    {
    
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public string Brand { get; set; }
 
        // public byte[] Image { get; set; }
        public string Picture { get; set; }
        public Product()
        {

        }
        public Product(string ProductName, int Quantity, double UnitPrice, double Discount, string Brand
            , string CategoryName, string Description): base(CategoryName, Description)
        {
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.Discount = Discount;
            this.Brand = Brand;
        }
      
    }
}