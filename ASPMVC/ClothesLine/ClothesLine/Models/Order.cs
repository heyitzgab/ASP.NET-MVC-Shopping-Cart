
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesLine.Models
{
    public class Order
    {
        public int Id { get; set; }
    
        public DateTime ShippedDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
     

        public virtual Product Product { get; set; }

    }
}