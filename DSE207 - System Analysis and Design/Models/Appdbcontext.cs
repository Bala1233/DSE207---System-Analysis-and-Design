using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DSE207___System_Analysis_and_Design.Models
{
    public class Appdbcontext : DbContext
    {
        public DbSet<Product> ProductTable { get; set; }
        public DbSet<Customer> CustomerTable { get; set; }
        public DbSet<Cart> CartTable { get; set; }
        public DbSet<Admin> AdminTable { get; set; }
        public DbSet<Seller> SellerTable { get; set; }
        public DbSet<NewTransactionHistory> TransactionHistoryTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuider)
        {
            optionBuider.UseSqlServer(@"Server=LAPTOP-96CR6G1G\SQLEXPRESS;Database= DSE207___System_Analysis_and_Design ;Trusted_Connection=True;");
        }
    }
}
