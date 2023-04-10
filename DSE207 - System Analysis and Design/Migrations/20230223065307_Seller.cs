using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSE207___System_Analysis_and_Design.Migrations
{
    public partial class Seller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Seller_Id",
                table: "ProductTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seller_Id",
                table: "ProductTable");
        }
    }
}
