using System.ComponentModel.DataAnnotations;

namespace DSE207___System_Analysis_and_Design.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string? CartId { get; set; }

        public int? Qty { get; set; }
        public DateTime CreateTime { get; set; }
        public string? Status { get; set; }

        public string? CustomerId { get; set; }

        public string? ProductId { get; set; }
        public string SellerId { get; set; }
    }
}
