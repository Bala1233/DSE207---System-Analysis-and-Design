using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSE207___System_Analysis_and_Design.Migrations
{
    public partial class productsstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "ProductTable",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductTable");
        }
    }
}
