using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSE207___System_Analysis_and_Design.Migrations
{
    public partial class SalesPer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sales",
                table: "ProductTable",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sales",
                table: "ProductTable");
        }
    }
}
