using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class SellerFunctionController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        public IActionResult SellerLoginFunction(string Username, string Password)
        {
            var checklogin = db.SellerTable.Where(e => e.Username == Username && e.Password == Password).FirstOrDefault();
            if (checklogin != null && checklogin.Inverify == true)
            {
                //Login
                HttpContext.Session.SetString("Seller", checklogin.SellerId);
                return Json("Success");
            }
            else
            {
                return Json("Fail");
            }
        }
        public IActionResult SellerLoout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("MerchandisePage", "CustomerStore");
        }
    }
}
