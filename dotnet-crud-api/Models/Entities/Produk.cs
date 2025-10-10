using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_crud_api.Models.Entities
{
    public class Produk
    {
        public int Id { get; set; }

        [Required]
        public string Nama { get; set; } = string.Empty;

        [Range(0.01, 1000000000)]
        public decimal Harga { get; set; }

        [Required]
        public int KategoriId { get; set; }

        public Kategori? Kategori { get; set; }

    }
}
