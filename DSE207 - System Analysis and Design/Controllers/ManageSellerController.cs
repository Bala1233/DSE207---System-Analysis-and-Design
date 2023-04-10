using DSE207___System_Analysis_and_Design.Models;
using DSE207___System_Analysis_and_Design.Models.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Twilio.Rest.Chat.V1.Service;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class ManageSellerController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        public IActionResult SellerList()
        {

            return View(db.SellerTable);
        }
        //============================================Seller=====================================================
        public IActionResult SellerLoginPage()
        {
            return View();
        }

        public IActionResult CreateSeller()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSeller(Seller seller)
        {
            seller.SellerId = String.Format("S-{0}", (db.SellerTable.OrderBy(x => x.Id).Last().Id + 1).ToString("0000"));
            db.SellerTable.Add(seller);
            db.SaveChanges();
            return Json(true);
        }


        public IActionResult CustomerPotentialSeller()
        {
            var x = HttpContext.Session.GetString("LoginUser");
            var y = HttpContext.Session.GetString("Seller");
            var CustomerPotentail = db.CartTable.Where(e => e.SellerId == y && e.Status == "Pending").ToList();
            var CustomerTesting = db.CustomerTable.ToList();
            var ProductList = db.ProductTable.ToList();
            List<potentialViewmodel> PotenialCustomer = new List<potentialViewmodel>();

            foreach (var customer in CustomerPotentail)
            {
                var selectedCus = CustomerTesting.FirstOrDefault(e => e.CustomerId == customer.CustomerId);
                var selectedPro = ProductList.FirstOrDefault(e => e.ProductId == customer.ProductId);
                if (selectedCus != null)
                {

                    PotenialCustomer.Add(new potentialViewmodel
                    {
                        customerName = selectedCus.FullName,
                        productName = selectedPro!.ProductName,
                        phoneNumber = selectedCus.Phone,
                        email = selectedCus.Email,
                    });

                }
            }
            return View(PotenialCustomer);
        }
        public IActionResult DashBoard()
        {
            var x = HttpContext.Session.GetString("Seller");

            if (x == null)
            {
                return RedirectToAction("SellerLoginPage");
            }
            else
            {
                return View();
            }
     
        }
    }
}
