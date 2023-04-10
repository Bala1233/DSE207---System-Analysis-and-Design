using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class AdminFunctionController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        [HttpPost]
        public IActionResult AdminLoginPage(string Email, string Password)
        {
            var checklogin = db.CustomerTable.Where(e => e.Email == Email && e.Password == Password).FirstOrDefault();

            if (checklogin != null && checklogin.Id == 1)
            {
                //Login
                HttpContext.Session.SetString("Admin", checklogin.CustomerId);
                return Json("Success");
            }
            else
            {
                return Json("Fail");
            }
        }
        public IActionResult Admin_Status_True(string ProductId)
        {
            var SelectedProducts = db.ProductTable.Where(e => e.ProductId == ProductId).FirstOrDefault();
            SelectedProducts.Status = SelectedProducts.Status == true ? false : true;
            db.SaveChanges();
            return Json(SelectedProducts.Status);
        }
        public IActionResult Admin_Verify_Seller(string SellerId)
        {
            var SelectedSeller = db.SellerTable.Where(e => e.SellerId == SellerId).FirstOrDefault();
            SelectedSeller.Inverify = SelectedSeller.Inverify == true ? false : true;

            db.SaveChanges();
            return Json(SelectedSeller.Inverify);
        }
        public IActionResult Admin_Edit_Customer_Password(string CustomerId)
        {
            var SelectedCustomerId = db.CustomerTable.Where(e => e.CustomerId == CustomerId).FirstOrDefault();
            SelectedCustomerId.Password = "Admin123";
            db.SaveChanges();
            return Json(SelectedCustomerId.Password);
        }
        public IActionResult Admin_Edit_Customer_Status(string CustomerId)
        {
            var SelectedCustomerId = db.CustomerTable.Where(e => e.CustomerId == CustomerId).FirstOrDefault();
            SelectedCustomerId.Status = SelectedCustomerId.Status == true ? false : true;
            db.SaveChanges();
            return Json(SelectedCustomerId.Status);
        }
        public IActionResult Admin_Manage_ProductAjax(string SellerId)
        {
            var Selected_Seller_Product = db.ProductTable.Where(e => e.SellerId == SellerId).ToList();
            if (Selected_Seller_Product.Count <= 0)
            {
                return Json("Null");
            }
            else
            {
                return Json("Success");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("MerchandisePage", "CustomerStore");
        }
        [HttpPost]
        public ActionResult MultiActiveSeller(string[] ProductIdArray)
        {
            foreach (var product in ProductIdArray)
            {
                var foundProduct = db.SellerTable.FirstOrDefault(e => e.SellerId == product);
                foundProduct!.Inverify = true;

            }
            db.SaveChanges();
            return Json("");
        }
        [HttpPost]
        public ActionResult MultiDisabledSeller(string[] ProductIdArray)
        {
            foreach (var product in ProductIdArray)
            {
                var foundProduct = db.SellerTable.FirstOrDefault(e => e.SellerId == product);
                foundProduct!.Inverify = false;

            }
            db.SaveChanges();
            return Json("");
        }
        [HttpPost]
        public ActionResult MultiActiveSellerProduct(string[] ProductIdArray)
        {
            foreach (var product in ProductIdArray)
            {
                var foundProduct = db.ProductTable.FirstOrDefault(e => e.ProductId == product);
                foundProduct!.Status = true;

            }
            db.SaveChanges();
            return Json("");
        }
        [HttpPost]
        public ActionResult MultiDisabledSellerProduct(string[] ProductIdArray)
        {
            foreach (var product in ProductIdArray)
            {
                var foundProduct = db.ProductTable.FirstOrDefault(e => e.ProductId == product);
                foundProduct!.Status = false;

            }
            db.SaveChanges();
            return Json("");
        }
    }
}
