using System.Security.Cryptography.X509Certificates;

namespace DSE207___System_Analysis_and_Design.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string SellerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public bool Inverify { get; set; }
    }
}
