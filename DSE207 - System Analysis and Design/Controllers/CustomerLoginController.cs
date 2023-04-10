using DSE207___System_Analysis_and_Design.Models;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace DSE207___System_Analysis_and_Design.Controllers
{
    public class CustomerLoginController : Controller
    {
        public Appdbcontext db = new Appdbcontext();
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(string Email, string password)
        {
            var checklogin = db.CustomerTable.Where(e => e.Email == Email && e.Password == password).FirstOrDefault();
            //if (checklogin != null && checklogin.Id == 1)
            //{
            //    HttpContext.Session.SetString("LoginUser", checklogin.CustomerId);
            //    return RedirectToAction("ProductList", "ManageProducts");

            //}
            if (checklogin != null && checklogin.Id != 1 && checklogin.Status==true)
            {
                HttpContext.Session.SetString("LoginUser", checklogin.CustomerId);
                return Json(checklogin);
            }
          
            else
            {
                return Json("Faild");
            }

        }
        [HttpPost]
        public IActionResult Register(Customer NewcCustomer)
        {
            NewcCustomer.CustomerId = Guid.NewGuid().ToString();
            db.CustomerTable.Add(NewcCustomer);
            db.SaveChanges();
            return Json(true);
        }

        public IActionResult RegisterOtpAjax(string Phone)
        {
            Random random = new Random();
            const string chars = "ABCDERFGIHJLMNOPTRSQWXYZ1234567890";
            var x = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var accountSid = "AC012cca67c576a223e5d0c3dd59ca9a44";
            var authToken = "941d5f86fdecc03c584c801274248e9b";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("+60174093109"));
            messageOptions.MessagingServiceSid = "MG005721b873528a8a66740e1194f0ed9a";
            messageOptions.Body = "Ur Otp is " + x;

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
            return Json(x);
        }
    }
}
