using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VAGnificent.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingCEOrowseedingBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEO",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CEO",
                value: "Stefan Vinkelman");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEO",
                table: "Brands");
        }
    }
}
