using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_6_10.Migrations
{
    /// <inheritdoc />
    public partial class testEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categoties_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategotyId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategotyId",
                table: "Products",
                column: "CategotyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categoties_CategotyId",
                table: "Products",
                column: "CategotyId",
                principalTable: "Categoties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categoties_CategotyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategotyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategotyId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categoties_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categoties",
                principalColumn: "Id");
        }
    }
}
