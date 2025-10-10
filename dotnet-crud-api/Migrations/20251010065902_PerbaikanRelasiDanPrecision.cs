using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_crud_api.Migrations
{
    /// <inheritdoc />
    public partial class PerbaikanRelasiDanPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kategori",
                columns: new[] { "Id", "Nama" },
                values: new object[,]
                {
                    { 1, "Umum" },
                    { 2, "Elektronik" },
                    { 3, "Buku" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kategori",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategori",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kategori",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
