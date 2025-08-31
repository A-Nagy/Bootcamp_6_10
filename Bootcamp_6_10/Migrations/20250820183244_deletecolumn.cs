using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_6_10.Migrations
{
    /// <inheritdoc />
    public partial class deletecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Countery",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Countery",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
