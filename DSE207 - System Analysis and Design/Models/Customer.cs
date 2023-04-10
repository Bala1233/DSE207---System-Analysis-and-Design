using System.ComponentModel.DataAnnotations;

namespace DSE207___System_Analysis_and_Design.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
