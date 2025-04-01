using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCApp.Migrations
{
    /// <inheritdoc />
    public partial class _16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShopAddress",
                table: "shops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Prafull");

            migrationBuilder.AddColumn<int>(
                name: "price3",
                table: "shops",
                type: "int",
                nullable: false,
                defaultValue: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopAddress",
                table: "shops");

            migrationBuilder.DropColumn(
                name: "price3",
                table: "shops");
        }
    }
}
