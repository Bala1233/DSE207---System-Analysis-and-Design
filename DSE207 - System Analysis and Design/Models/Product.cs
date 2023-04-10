using System.ComponentModel.DataAnnotations;

namespace DSE207___System_Analysis_and_Design.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double OriPrice { get; set; }
        public double DisPrice { get; set; }
        public int Qty { get; set; }
        public string ProductImg1 { get; set; }
        public string? ProductImg2 { get; set; }
        public string? DetailsImg1 { get; set; }
        public string? DetailsImg2 { get; set; }
        public string? DetailsImg3 { get; set; }
        public string SellerId { get; set; }
        public bool Status { get; set; }
        public int? Sales { get; set; }
    }
}
