using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClothesLine.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public int OrderId { get; set; }

        public string LoginErrorMessage { get; set; }
        public Customer()
        {

        }
        public Customer(string FirstName, string LastName, string Password, string Email, int Phone, string Address)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
        }
        public virtual ICollection<Order> Orders { get; set; }
    }
}