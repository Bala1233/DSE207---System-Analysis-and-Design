using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class CustomerProfilesController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        public IActionResult Profile()
        {
            var x = HttpContext.Session.GetString("LoginUser");
            var UserID = db.CustomerTable.Where(e => e.CustomerId == x).FirstOrDefault();
            if(UserID == null)
            {
                return RedirectToAction("LoginPage", "CustomerLogin");
            }
            return View(UserID);
        }
        [HttpPost]
        public IActionResult Profile(Customer customer)
        {
            var UserID = db.CustomerTable.Where(e => e.CustomerId == customer.CustomerId).FirstOrDefault();
            UserID.FullName = customer.FullName;
            UserID.Password = customer.Password;
            UserID.Phone = customer.Phone;
            UserID.Adress = customer.Adress;
            UserID.ImageUrl = customer.ImageUrl;

            db.SaveChanges();
            return Json(UserID);
        }
    }
}
