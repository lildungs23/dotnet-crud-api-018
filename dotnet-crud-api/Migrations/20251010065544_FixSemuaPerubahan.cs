using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_crud_api.Migrations
{
    /// <inheritdoc />
    public partial class FixSemuaPerubahan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Produk",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nama = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produk_KategoriId",
                table: "Produk",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produk_Kategori_KategoriId",
                table: "Produk",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produk_Kategori_KategoriId",
                table: "Produk");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropIndex(
                name: "IX_Produk_KategoriId",
                table: "Produk");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Produk");
        }
    }
}
