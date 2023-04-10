using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSE207___System_Analysis_and_Design.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriPrice = table.Column<double>(type: "float", nullable: false),
                    DisPrice = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    ProductImg1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImg2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailsImg1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailsImg2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailsImg3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistoryTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaidTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeansactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BullingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistoryTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTable");

            migrationBuilder.DropTable(
                name: "CartTable");

            migrationBuilder.DropTable(
                name: "CustomerTable");

            migrationBuilder.DropTable(
                name: "ProductTable");

            migrationBuilder.DropTable(
                name: "TransactionHistoryTable");
        }
    }
}
