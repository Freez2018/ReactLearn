using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addProductsMatching2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsMatching",
                columns: table => new
                {
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    BaseProductId = table.Column<string>(nullable: true),
                    MatchProductId = table.Column<string>(nullable: true),
                    Rate1 = table.Column<double>(nullable: false),
                    Rate2 = table.Column<double>(nullable: false),
                    Rate3 = table.Column<double>(nullable: false),
                    UserAddedId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsMatching", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsMatching_Product_BaseProductId",
                        column: x => x.BaseProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsMatching_Product_MatchProductId",
                        column: x => x.MatchProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsMatching_BaseProductId",
                table: "ProductsMatching",
                column: "BaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsMatching_MatchProductId",
                table: "ProductsMatching",
                column: "MatchProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsMatching");
        }
    }
}
