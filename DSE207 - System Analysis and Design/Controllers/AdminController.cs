using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Text.Json.Serialization;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class AdminController : Controller
    {
        Appdbcontext db = new Appdbcontext();

        public IActionResult AdminLoginPage()
        {
            return View();
        }

        public IActionResult AdminManageProducts(string SellerId)
        {
            var Selected_Seller_Product = db.ProductTable.Where(e => e.SellerId == SellerId).ToList();
            return View(Selected_Seller_Product);
        }
        public IActionResult AdminManageCustomer()
        {
            return View(db.CustomerTable);
        }
        public IActionResult AdminEditCustomer(Customer customer)
        {
            var SelectedCustomer = db.CustomerTable.Where(e => e.CustomerId == customer.CustomerId).FirstOrDefault();
            return View(SelectedCustomer);
        }
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}

