using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothesLine.Models;
using ClothesLine.DB;
using System.Diagnostics;

namespace ClothesLine.Controllers
{
    public class HomeController : Controller
    {
        ClothesLineDbContext context = new ClothesLineDbContext();
        static int count = 0;
        public ActionResult Index()
        {
            //return RedirectToAction("Gallery", "Home");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(string username, string password)
        {
            if (Session["username"] != null)
                return RedirectToAction("Gallery", "Home");

            if (username == null)
                return View();

            Session["username"] = username;
            Session["productId"] = new List<string>();
            Session["quantity"] = new List<string>();

            return RedirectToAction("Gallery", "Home");
        }



        [HttpPost]
        public ActionResult Authorize(ClothesLine.Models.Customer userModel)
        {
            using (ClothesLineDbContext db = new ClothesLineDbContext())
            {
                var userDetails = db.Customers.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong Username or Password.";
                    return View("Gallery", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.Id;
                    Session["username"] = userDetails.Email;
                    return RedirectToAction("Gallery", "Home");
                }
            }
        }

        /* //Logout
         public ActionResult Logout()
         {
             Session.Clear();
             return View("Login");
        }*/
        public ActionResult Gallery(string searchStr = "")
        {
            if (Session["username"] == null)
                return RedirectToAction("Login", "Home");

            List<Product> pro = new List<Product>();

            //when the first time user come into the program, assume the searchStr as null  
            //and retrieve all the data from database
            var iter = from p in context.Products
                       select new
                       {
                           p.Id,
                           p.Picture,
                           p.ProductName,
                           p.Description,
                           p.UnitPrice,
                           p.Brand
                       };


            foreach (var i in iter)
            {
                Product pd = new Product();
                pd.Id = i.Id;
                pd.Picture = i.Picture;
                pd.ProductName = i.ProductName;
                pd.Description = i.Description;
                pd.UnitPrice = i.UnitPrice;
                pd.Brand = i.Brand;

                pro.Add(pd);
            }
          
            ViewBag.username = (string)Session["username"];
            ViewBag.productList = pro;
            ViewBag.found = true;
            ViewBag.searchString = searchStr;
            //find the product name that matches with searchStr

            //retrieve product Id, and other attributes depending on product name
            //pass the ProductList into view
            //found= true/false should be pass to view 
            ViewBag.proList = TempData["pL"];
            ViewBag.orQuantity = TempData["oQ"];           
            ViewBag.count = TempData["count"];
            TempData.Keep();
            return View();
        }

        public ActionResult AddToCart(int productId, int quantity)
        {
            Customer c = new Customer();
                Order order = new Order();
                c.FirstName = (string)Session["username"];
                count = count + quantity;
                if (productId != 0)
                {
                    order.ProductId = productId;
                    order.ShippedDate = DateTime.Today;
                    order.Quantity = quantity;
                   
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            List<int> productList = (List<int>)Session["productIdSession"];
            productList.Add(productId);
            List<int> orderQuantity = (List<int>)Session["quantitySession"];
            orderQuantity.Add(quantity);
            c.OrderId = order.Id;
            
            TempData["count"] = count;
            List<int> pList = (List<int>)Session["productIdSession"];
           // TempData["pL"] = pList;
            List<int> oQuantity = (List<int>)Session["quantitySession"];
           // TempData["oQ"] = oQuantity;
            TempData.Keep();
          
            context.Customers.Add(c);
            context.SaveChanges();
          
            return RedirectToAction("Gallery", "Home");
        }
        public ActionResult MyPurchases()
        {
            return View();
        }

        public ActionResult Cart()
        {          
            List<Product> pro = new List<Product>();
            List<int> pList = (List<int>)Session["productIdSession"];
            List<int> oQuantity = (List<int>)Session["quantitySession"];
            //Debug.WriteLine(pid);
            var iter = from o in context.Orders
                        group o by o.ProductId into grp
                        select new { key = grp.Key,
                            Count = grp.Count()
                        };


             
            foreach (var g in iter)
                {
                    Debug.WriteLine("{0}", g.Count);
                   

                }
          
           /* var it=from order in context.Orders
                   from product in context.Products
                   where order.ProductId==product.Id*/








            /* var iter =
                        from c in context.Products
                            // from v in db.Categories

                        select new
                        {
                            c.ProductName,
                            c.Description,
                            c.Picture,
                            c.UnitPrice,
                            c.Quantity
                        };

             foreach (var i in iter)

             {
                 Product pd = new Product();
                 //Category cd = new Category();

                 pd.ProductName = i.ProductName;
                 pd.Description = i.Description;
                 pd.Picture = i.Picture;
                 pd.UnitPrice = i.UnitPrice;
                 pd.Quantity = i.Quantity;
                 //cd.CategoryName = i.CategoryName;
                 pro.Add(pd);
                 //cat.Add(cd);

             }*/
            ViewBag.productList = pro;
            //ViewBag.categoryList = cat;
            return View();
        }

    }
}