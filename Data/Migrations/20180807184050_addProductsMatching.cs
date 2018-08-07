using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addProductsMatching : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAddedId",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAddedId",
                table: "Product");
        }
    }
}
