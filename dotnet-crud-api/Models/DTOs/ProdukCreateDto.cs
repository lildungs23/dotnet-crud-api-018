using System.ComponentModel.DataAnnotations;

namespace dotnet_crud_api.Models.DTOs
{
    public class ProdukCreateDto
    {
        [Required(ErrorMessage = "Nama produk wajib diisi.")]
        [StringLength(100, ErrorMessage = "Nama produk maksimal 100 karakter.")]
        public string Nama { get; set; } = string.Empty;

        [Required(ErrorMessage = "Harga wajib diisi.")]
        [Range(0.01, 1000000000, ErrorMessage = "Harga harus antara 0.01 dan 1.000.000.000.")]
        public decimal Harga { get; set; }

        [Required(ErrorMessage = "Kategori wajib diisi.")]
        public int KategoriId { get; set; }
    }
}
