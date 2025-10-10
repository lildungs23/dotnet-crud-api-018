using System;

namespace dotnet_crud_api.Models.DTOs
{
    public class ProdukReadDto
    {
        public int Id { get; set; }
        public string Nama { get; set; } = string.Empty;
        public decimal Harga { get; set; }
        public int Stok { get; set; }
        public int KategoriId { get; set; }
        public string? KategoriNama { get; set; }   // agar tampil di response
        public DateTime TanggalDibuat { get; set; }
    }
}
