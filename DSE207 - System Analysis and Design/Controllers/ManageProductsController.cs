using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;


namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class ManageProductsController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        public IActionResult ProductList(string SellerId)
        {
            var x = HttpContext.Session.GetString("Seller");
            var ShowProduct = db.ProductTable.Where(e => e.SellerId == x && e.Status == true);
            return View(ShowProduct);
        }
        public IActionResult CreateProducts()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProducts(Product products)
        {
            products.ProductId = String.Format("P-{0}", (db.ProductTable.OrderBy(x => x.Id).Last().Id + 1).ToString("0000"));
            products.SellerId = HttpContext.Session.GetString("Seller");
            products.Status = true;
            products.Sales = 0;
            //SellerId != Null
            db.ProductTable.Add(products);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public IActionResult EditProducts(string ProductId)
        {
            var SelectedProduct = db.ProductTable.Where(e => e.ProductId == ProductId).FirstOrDefault();
            return View(SelectedProduct);
        }
        [HttpPost]
        public IActionResult EditProducts(Product EditProduct)
        {
            var SelectedProduct = db.ProductTable.Where(e => e.ProductId == EditProduct.ProductId).FirstOrDefault();
            SelectedProduct.ProductName = EditProduct.ProductName;
            SelectedProduct.Title = EditProduct.Title;
            SelectedProduct.Description = EditProduct.Description;
            SelectedProduct.OriPrice = EditProduct.OriPrice;
            SelectedProduct.DisPrice = EditProduct.DisPrice;
            SelectedProduct.Qty = EditProduct.Qty;
            SelectedProduct.ProductImg1 = EditProduct.ProductImg1;
            SelectedProduct.ProductImg2 = EditProduct.ProductImg2;
            SelectedProduct.DetailsImg1 = EditProduct.DetailsImg1;
            SelectedProduct.DetailsImg2 = EditProduct.DetailsImg2;
            SelectedProduct.DetailsImg3 = EditProduct.DetailsImg3;
            db.SaveChanges();
            return RedirectToAction("productList");
        }
        public IActionResult RemoveProduct(string ProductId)
        {
            var SelectedProduct = db.ProductTable.Where(e => e.ProductId == ProductId).FirstOrDefault();
            if (SelectedProduct != null)
            {
                SelectedProduct.Status = false;
                db.SaveChanges();
                return Json("Remove");
            }
            else
            {
                return Json("Nothing");
            }
        }

        [HttpPost]
        public ActionResult MultiDeleteProduct(string[] ProductIdArray)
        {
            foreach (var product in ProductIdArray)
            {
                var foundProduct = db.ProductTable.FirstOrDefault(e => e.ProductId == product);
                foundProduct.Status = false;
            }
            db.SaveChanges();
            return Json("");
        }

        public ActionResult GetTop5ProductSales()
        {
            var x = HttpContext.Session.GetString("Seller");
            var SellerProduct = db.ProductTable.Where(e => e.SellerId == x)
                .OrderByDescending(e => e.Sales)
                .ToList();
            SellerProduct = SellerProduct.Take(SellerProduct.Count() > 5 ? 5 : SellerProduct.Count()).ToList();
            return Json(SellerProduct);
        }
        public ActionResult GetMonthlyIncome()
        {
            double[] Income = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var x = HttpContext.Session.GetString("Seller");

            var SellerOrders = db.CartTable.Where(e => e.SellerId == x && e.Status == "Paid").ToList();

            var SellersOrder = (from o in SellerOrders
                                join p in db.ProductTable on o.ProductId equals p.ProductId
                                select new { o, p }).ToList();

            for (int i = 0; i <= 11; i++)
            {
                Income[i] = (double)SellersOrder.Where(e => e.o.CreateTime.Month == i+1).Sum(e => e.o.Qty * e.p.DisPrice)!;
            }

            return Json(Income);
        }
    }
}
