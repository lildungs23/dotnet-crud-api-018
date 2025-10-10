using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_crud_api.Migrations
{
    /// <inheritdoc />
    public partial class HapusKolomStok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stok",
                table: "Produk");

            migrationBuilder.DropColumn(
                name: "TanggalDibuat",
                table: "Produk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stok",
                table: "Produk",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanggalDibuat",
                table: "Produk",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
