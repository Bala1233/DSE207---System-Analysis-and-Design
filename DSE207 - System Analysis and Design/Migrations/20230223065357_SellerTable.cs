using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSE207___System_Analysis_and_Design.Migrations
{
    public partial class SellerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminTable",
                table: "AdminTable");

            migrationBuilder.RenameTable(
                name: "AdminTable",
                newName: "Admin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "AdminTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminTable",
                table: "AdminTable",
                column: "Id");
        }
    }
}
