using System.ComponentModel.DataAnnotations;

namespace DSE207___System_Analysis_and_Design.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
