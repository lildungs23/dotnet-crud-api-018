using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_crud_api.Models.Entities
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nama { get; set; } = string.Empty;

        // Relasi 1 ke banyak (Kategori -> Produk)
        public ICollection<Produk>? Produks { get; set; }
    }
}
