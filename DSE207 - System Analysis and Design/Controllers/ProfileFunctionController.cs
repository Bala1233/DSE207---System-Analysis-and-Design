using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class ProfileFunctionController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        public IActionResult Profile_Ajax()
        {
            var UserLogin = HttpContext.Session.GetString("LoginUser");
            if (UserLogin == null)
            {
                return Json("Nothing");
            }
            else
            {
                return Json("FoundUser");
            }
        }

        public IActionResult CustomerProfiles()
        {
            var UserLogin = HttpContext.Session.GetString("LoginUser");
            var SelectesCustomer = db.CustomerTable.Where(e => e.CustomerId == UserLogin).FirstOrDefault();
            return Json(SelectesCustomer);
        }
    }
}
