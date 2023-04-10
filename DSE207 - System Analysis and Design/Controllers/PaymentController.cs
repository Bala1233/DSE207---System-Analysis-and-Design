using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class PaymentController : Controller
    {
        Appdbcontext db = new Appdbcontext();
        private readonly DtoStripeSecrets _stripeSecrets;
        static DtoStripeSecrets stripeSecrets = new DtoStripeSecrets()
        {
            SecretKey = "sk_test_51MPL3JKSABYpvqxZUXPDRcdK71flE35gVzFIHPrwoQX33fy3ayMvxLvdGQkoR53xQu74hFqSn498nEZjawLCUcmX00Tf1Ta32A",
            PublishableKey = "pk_test_51MPL3JKSABYpvqxZb6iqprezBvO179yT5FPU92412cR37xFj1v6vp67BzsXdL6Q7uL0AZVvPy0brPCFzWgQ66UrY00dyI9fVxU"
        };
        public static double GrandTotalAmount { get; set; }

        public static string TransactionId { get; set; }
        public IActionResult PaymentCheckoutPage(double GrandTotal, double SumToal)
        {
            ViewBag.GrandTotal = GrandTotal;
            GrandTotalAmount = GrandTotal;

            var x = HttpContext.Session.GetString("LoginUser");


            var selectedCart = db.CartTable.Where(z => z.CustomerId == x && z.Status == "Pending").Select(z => z.Id).ToList();

            var cartlist = string.Join(",", selectedCart);
            if (HttpContext.Session.GetString("LoginUser") == null)
            {
                return RedirectToAction("MerchandisePage", "CustomerStore");
            }
            else
            {
                TransactionId = "Transaction-" + Guid.NewGuid().ToString();
                db.TransactionHistoryTable.Add(new NewTransactionHistory
                {
                    TransactionId = TransactionId,
                    CartList = cartlist,
                    CreateTime = DateTime.Now.ToString(),
                    BullingAddress = "Sample Address",
                    PaidTime = "Not Yet Update",
                    SubTotal = SumToal,
                    GrandTotal = GrandTotal,
                    Tax = 0,
                    TeansactionStatus = "Pending",
                    User_Id = x.ToString(),
                    Description = "Stripe CC Payment"

                });

                db.SaveChanges();
                return View();
            }

        }

        [HttpPost] //When Clicked Submid
        public IActionResult PaymentCheckoutPage(CreditCard creditCard)
        {
            var LoginUser = db.CustomerTable.FirstOrDefault(e => e.CustomerId == HttpContext.Session.GetString("LoginUser"));

            try
            {
                var total = Convert.ToInt64(GrandTotalAmount) * 100;
                StripePayment stripePayment = new StripePayment(new CreditCard
                {

                    Name = LoginUser.FullName,
                    Email = LoginUser.Email,
                    AddressLine1 = LoginUser.Adress,
                    AddressLine2 = "-",
                    AddressCity = "-",
                    AddressState = "-",
                    AddressZip = "-",
                    Descripcion = $"Purchase on {DateTime.Now:d}",
                    DetailsDescripcion = $"More {DateTime.Now:d}",
                    Amount = total /*data.Amount*/, //2000 = 20.00   10000 == ??
                    Currency = "MYR",
                    Number = $"{creditCard.CardNumber1} {creditCard.CardNumber2} {creditCard.CardNumber3} {creditCard.CardNumber4}",//4242 4242 4242 4242
                    ExpMonth = creditCard.expMonth,
                    ExpYear = creditCard.expYear,
                    Cvc = creditCard.Cvc //123

                }, stripeSecrets);
                Charge charge = stripePayment.ProccessPayment();
                //Success Pat record
                var selectedTransaction = db.TransactionHistoryTable.Where(x => x.TransactionId == TransactionId).FirstOrDefault();

                selectedTransaction.TeansactionStatus = "Payment Successed";
                selectedTransaction.PaidTime = DateTime.Now.ToString();

                foreach (var Suc in selectedTransaction.CartList.Split(","))
                {
                    var Seachcartid = db.CartTable.Where(e => e.Id == Convert.ToInt32(Suc)).FirstOrDefault();
                    var ProductQty = db.ProductTable.Where(e => e.ProductId == Seachcartid.ProductId).FirstOrDefault();
                    Seachcartid.Status = "Paid";
                    ProductQty.Qty -= (int)Seachcartid.Qty;
                    ProductQty.Sales += (int)Seachcartid.Qty;
                }

                db.SaveChanges();
                return RedirectToAction("PaymentSuccessPage");
            }
            catch (Exception ex)
            {
                var selectedTransaction = db.TransactionHistoryTable.Where(x => x.TransactionId == TransactionId).FirstOrDefault();
                selectedTransaction.TeansactionStatus = "Payment Failed";
                selectedTransaction.PaidTime = DateTime.Now.ToString();
                db.SaveChanges();
                return RedirectToAction("PaymentErrorPage", "Payment", new { Msg = ex.Message });
            }

        }
        public IActionResult PaymentErrorPage(string Msg)
        {
            ViewBag.Msg = Msg;
            return View();
        }
        public IActionResult PaymentSuccessPage(double GrandTotal)
        {
            ViewBag.GrandTotal = GrandTotal;
            return View();
        }
    }
}
