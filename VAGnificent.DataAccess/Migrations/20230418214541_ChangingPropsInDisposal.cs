using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VAGnificent.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangingPropsInDisposal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disposals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "TravelledDistance",
                table: "Disposals",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "EngineCapacity",
                table: "Disposals",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "DollarsPrice",
                table: "Disposals",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 999999);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TravelledDistance",
                table: "Disposals",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "EngineCapacity",
                table: "Disposals",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "DollarsPrice",
                table: "Disposals",
                type: "decimal(18,2)",
                maxLength: 999999,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Disposals",
                columns: new[] { "Id", "Accidents", "BrandCountry", "BrandId", "Colour", "DollarsPrice", "EngineCapacity", "FuelType", "HorsePower", "ImageUrl", "Model", "TransmisionType", "TravelledDistance", "Weight", "Year" },
                values: new object[] { 1, true, "Germany", 5, "White", 100000m, 3000.0, "Gazoline", 420, null, "911 922 Turbo", "Robo", 0.0, 1300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021) });
        }
    }
}
