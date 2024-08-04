using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lagoon.Infra.Migrations
{
    /// <inheritdoc />
    public partial class VillaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "ID", "CreatedDate", "Desc", "ImageUrl", "Name", "Price", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "No Desc", "https://placehold.co/600x400", "Royal Villa 1", 200.0, 550, null },
                    { 2, null, "No Desc", "https://placehold.co/600x400", "Royal Villa 2", 200.0, 550, null },
                    { 3, null, "No Desc", "https://placehold.co/600x400", "Royal Villa 3", 200.0, 550, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
