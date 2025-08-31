using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bootcamp_6_10.Migrations
{
    /// <inheritdoc />
    public partial class addnewpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Employees");
        }
    }
}
