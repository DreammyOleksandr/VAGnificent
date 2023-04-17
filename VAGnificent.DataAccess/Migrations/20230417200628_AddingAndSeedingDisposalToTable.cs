using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VAGnificent.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingAndSeedingDisposalToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    EngineCapacity = table.Column<double>(type: "float", nullable: false),
                    TransmisionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelledDistance = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DollarsPrice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 999999, nullable: false),
                    Accidents = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disposals_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Disposals",
                columns: new[] { "Id", "Accidents", "BrandCountry", "BrandId", "Colour", "DollarsPrice", "EngineCapacity", "FuelType", "HorsePower", "ImageUrl", "Model", "TransmisionType", "TravelledDistance", "Weight", "Year" },
                values: new object[] { 1, true, "Germany", 5, "White", 100000m, 3000.0, "Gazoline", 420, null, "911 922 Turbo", "Robo", 0.0, 1300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021) });

            migrationBuilder.CreateIndex(
                name: "IX_Disposals_BrandId",
                table: "Disposals",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disposals");
        }
    }
}
