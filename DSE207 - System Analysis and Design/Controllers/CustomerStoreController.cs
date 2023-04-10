using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class CustomerStoreController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        //public IActionResult MainPage()
        //{
        //    return View();
        //}
        public IActionResult MerchandisePage()
        {
            return View();
        }
        public IActionResult ForFilterAzurLanePage()
        {
            return View();
        }
        public IActionResult ForFilterMahjongSoulPage()
        {
            return View();
        }
        public IActionResult AzurLanePage()
        {
            return View();
        }
        public IActionResult MahjongSoulPage()
        {
            return View();
        }
        public IActionResult MerchandiseDetailsPage(int id)
        {
            var SelectedProducts = db.ProductTable.Where(e => e.Id == id).FirstOrDefault();

            return View(SelectedProducts);
        }
        public IActionResult CartList()
        {
            string cusId = HttpContext.Session.GetString("LoginUser");

            var cart = (from ct in db.CartTable
                        join pt in db.ProductTable on ct.ProductId equals pt.ProductId
                        select new CartProduct { cart = ct, product = pt }).ToList().Where(x => x.cart.CustomerId == cusId && x.cart.Status == "Pending");
            ViewBag.Count = cart.Where(e=>e.product.Status==true).Count();
            if (cusId != null)
            {
                return View(cart);
            }
            else
            {
                return RedirectToAction("LoginPage", "CustomerLogin");
            }
        }
    }
}
