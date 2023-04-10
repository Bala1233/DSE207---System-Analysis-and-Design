using System.ComponentModel.DataAnnotations;

namespace DSE207___System_Analysis_and_Design.Models
{
    public class NewTransactionHistory
    {
        [Key]
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public string CreateTime { get; set; }
        public string PaidTime { get; set; }
        public string TeansactionStatus { get; set; }
        public string CartList { get; set; }
        public string BullingAddress { get; set; }
        public string User_Id { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double GrandTotal { get; set; }
        public string? Description { get; set; }
    }
}
