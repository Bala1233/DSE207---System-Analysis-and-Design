using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class CartListFunctionController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        public IActionResult To_Cart_List(string ProductId, int Qty)
        {
            var x = HttpContext.Session.GetString("LoginUser");
            if (x == null)
            {
                return Json("Please Login");
            }
            else
            {
                return Json("CartList");
            }
        }
        public IActionResult TotalPrice()
        {
            string cusId = HttpContext.Session.GetString("LoginUser");
            var cart = (from ct in db.CartTable
                        join pt in db.ProductTable on ct.ProductId equals pt.ProductId
                        select new CartProduct { cart = ct, product = pt }).ToList().Where(x => x.cart.CustomerId == cusId && x.cart.Status == "Pending" && x.product.Status == true);


            var sum = cart.Sum(x => x.product.DisPrice * x.cart.Qty);
            return Json(sum);
        }
        public IActionResult CheckQty(string Cartid, int Qty)
        {
            string cusId = HttpContext.Session.GetString("LoginUser");

            var cart = (from ct in db.CartTable
                        join pt in db.ProductTable on ct.ProductId equals pt.ProductId
                        select new CartProduct { cart = ct, product = pt }).ToList().Where(x => x.cart.CartId == Cartid && x.cart.Status == "Pending");

            var gerCartRecord = db.CartTable.Where(x => x.CartId == Cartid).FirstOrDefault();

            var getProductRecord = db.ProductTable.Where(x => x.ProductId == gerCartRecord.ProductId).FirstOrDefault();
            if ((cart.FirstOrDefault().product.Qty - Qty) < 0)
            {
                gerCartRecord.Qty = cart.FirstOrDefault().product.Qty;
                db.SaveChanges();
                return Json("Stock Invalid/" + cart.FirstOrDefault().product.Qty);
            }
            if (Qty <= 0)
            {
                gerCartRecord.Qty = 1;
                db.SaveChanges();
                return Json("Invalid Number");
            }
            else
            {
                gerCartRecord.Qty = Qty;
                db.SaveChanges();
            }
            return Json("Success");
        }
        public IActionResult Cehcking_CartList_Items()
        {
            var LoginUser = HttpContext.Session.GetString("LoginUser");
            var cart = (from ct in db.CartTable
                        join pt in db.ProductTable on ct.ProductId equals pt.ProductId
                        select new CartProduct { cart = ct, product = pt }).ToList().Where(x => x.cart.CustomerId == LoginUser && x.cart.Status == "Pending");
            ViewBag.ItemCount = cart.Count();
            return Json(cart.Count());
        }
        public IActionResult Checking_Product_Status()
        {
            string cusId = HttpContext.Session.GetString("LoginUser");

            var cart = (from ct in db.CartTable
                        join pt in db.ProductTable on ct.ProductId equals pt.ProductId
                        select new CartProduct { cart = ct, product = pt }).ToList().Where(x => x.cart.CustomerId == cusId && x.cart.Status == "Pending");
            List<string> CartId = new List<string>();
            foreach (var item in cart)
            {
                if (item.product.Status == false)
                {
                    item.cart.Status = "Remove";
                    CartId.Add(item.cart.CartId!);
                }
            }
            db.SaveChanges();
            return Json(CartId);
        }
    }
}
