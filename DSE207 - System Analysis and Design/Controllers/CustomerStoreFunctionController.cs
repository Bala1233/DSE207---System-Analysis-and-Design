using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class CustomerStoreFunctionController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        public IActionResult GetAzurLaneProductList(string filter)
        {
            List<Product> ProductList = new List<Product>();
            if (filter == "manual")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "AzurLane" && e.Status == true).ToList();
            }
            else if (filter == "title-ascending")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "AzurLane" && e.Status == true).OrderBy(e => e.ProductName).ToList();
            }
            else if (filter == "title-descending")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "AzurLane" && e.Status == true).OrderByDescending(e => e.ProductName).ToList();
            }
            else if (filter == "price-ascending")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "AzurLane" && e.Status == true).OrderBy(e => e.DisPrice).ToList();
            }
            else if (filter == "price-descending")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "AzurLane" && e.Status == true).OrderByDescending(e => e.DisPrice).ToList();
            }
            return Json(ProductList);

        }
        public IActionResult GetAzurLaneDetails(int id)
        {
            var SelectedProducts = db.ProductTable.Where(e => e.Id == id).FirstOrDefault();
            return Json(SelectedProducts);
        }

        public IActionResult GetMahjongProductList(string filter)
        {
            List<Product> ProductList = new List<Product>();
            if (filter == "manual")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "Mahjong" && e.Status == true).ToList();
            }
            else if (filter == "title-ascending")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "Mahjong" && e.Status == true).OrderBy(e => e.ProductName).ToList();
            }
            else if (filter == "title-descending")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "Mahjong" && e.Status == true).OrderByDescending(e => e.ProductName).ToList();
            }
            else if (filter == "price-ascending")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "Mahjong" && e.Status == true).OrderBy(e => e.DisPrice).ToList();
            }
            else if (filter == "price-descending")
            {
                ProductList = db.ProductTable.Where(e => e.Title == "Mahjong" && e.Status == true).OrderByDescending(e => e.DisPrice).ToList();
            }
            return Json(ProductList);
        }

        public IActionResult AddtocartAjax(string ProductId, int Qty)
        {
            var x = HttpContext.Session.GetString("LoginUser");
            var SelectedProduct = db.ProductTable.Where(e => e.ProductId == ProductId).FirstOrDefault();
            var SelectedCart = db.CartTable.Where(e => e.ProductId == SelectedProduct.ProductId && e.CustomerId == x && e.Status == "Pending").FirstOrDefault();
            var AddCart = db.ProductTable.FirstOrDefault(x => x.ProductId == ProductId);
            if (x == null)
            {
                return Json("Please Login");
            }

            if (SelectedProduct!.Qty <= 0)
            {
                return Json("Out Of Stock");
            }
            if (SelectedProduct.Status == false)
            {
                return Json("Block");
            }

            if (SelectedCart == null)
            {
                Cart cart = new Cart();
                cart.CartId = Guid.NewGuid().ToString();
                //SelectedProduct.Qty -= Qty;
                cart.Qty = Qty;
                cart.CreateTime = DateTime.Now;
                cart.Status = "Pending";
                cart.CustomerId = HttpContext.Session.GetString("LoginUser");
                cart.ProductId = ProductId;
                cart.SellerId = SelectedProduct.SellerId;
                db.CartTable.Add(cart);
            }
            else
            {
                if (SelectedCart.Qty + Qty > AddCart.Qty)
                {
                    SelectedCart.Qty = AddCart.Qty;
                    return Json("Your cart is full");
                }
                else
                {
                    SelectedCart.Qty += Qty;
                };
            }
            db.SaveChanges();

            return Json("Added Successful");
        }
        public IActionResult SmallCartList()
        {
            string cusId = HttpContext.Session.GetString("LoginUser");

            var cart = (from ct in db.CartTable
                        join pt in db.ProductTable on ct.ProductId equals pt.ProductId
                        where ct.CustomerId == cusId && ct.Status == "Pending" && pt.Status == true
                        select new CartProduct { cart = ct, product = pt }).ToList();



            return Json(cart);
        }
        public IActionResult CustomerTable(string CustomerId)
        {
            var SelectedCus = db.CustomerTable.Where(e => e.CustomerId == CustomerId).FirstOrDefault();
            return Json(SelectedCus);
        }
        [HttpPost]
        public ActionResult GetProductStock(string productId)
        {
            var selectedProduct = db.ProductTable.FirstOrDefault(e => e.ProductId == productId);

            return Json(selectedProduct!.Qty);
        }

        [HttpPost]
        public IActionResult GetProductDetails(int id)
        {
            var SelectedProducts = db.ProductTable.Where(e => e.Id == id).FirstOrDefault();
            return Json(SelectedProducts);
        }
        public IActionResult CustomerLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage", "CustomerLogin");
        }
        [HttpPost]
        public int? AddQtyFunction(string CartId, int Qty)
        {
            var selectedcartid = db.CartTable.Where(x => x.CartId == CartId).FirstOrDefault();
            var searchproduct = db.ProductTable.Where(e => e.ProductId == selectedcartid.ProductId).FirstOrDefault();
            if (searchproduct.Qty <= selectedcartid.Qty)
            {
                return selectedcartid.Qty;
            }
            else
            {
                selectedcartid.Qty++;
                db.SaveChanges();
                return selectedcartid.Qty;
            }
        }
        [HttpPost]
        public int? MinusQtyFunction(string CartId, int Qty)
        {
            var selectedcartid = db.CartTable.Where(x => x.CartId == CartId).FirstOrDefault();
            selectedcartid.Qty--;
            db.SaveChanges();
            return selectedcartid.Qty;
        }

        public IActionResult ProductDetailsAddQty(string productid, int qty, string AddCheck)
        {
            var x = HttpContext.Session.GetString("LoginUser");
            var selectedproduct = db.ProductTable.Where(e => e.ProductId == productid).FirstOrDefault();

            if (x == null)
            {
                if (qty >= selectedproduct.Qty)
                {
                    return Json(false);
                }
                else
                {
                    return Json(true);
                }
            }
            else
            {
                var selectedcart = db.CartTable.Where(o => o.CustomerId == x && o.Status == "Pending" && o.ProductId == productid).FirstOrDefault();

                int? Total = selectedcart!.Qty + qty;

                if (AddCheck == "Add")
                {
                    if (Total > selectedproduct!.Qty)
                    {
                        return Json(false);
                    }
                    else
                    {
                        return Json(true);
                    }
                }
                else
                {
                    if (Total >= selectedproduct!.Qty)
                    {
                        return Json(false);
                    }
                    else
                    {
                        return Json(true);
                    }

                }


            }
        }

        public IActionResult CartRemoveAjax(string CartId)
        {
            var SelectedCart = db.CartTable.Where(x => x.CartId == CartId & x.Status == "Pending").FirstOrDefault();
            if (SelectedCart != null)
            {
                SelectedCart!.Status = "Remove";
                db.SaveChanges();
                return Json("Remove");
            }
            else
            {
                return Json("Nothing");
            }

        }


    }
}
