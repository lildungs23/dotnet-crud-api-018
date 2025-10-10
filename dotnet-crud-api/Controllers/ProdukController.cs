using dotnet_crud_api.Data;
using dotnet_crud_api.Models.DTOs;
using dotnet_crud_api.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_crud_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdukController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdukController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ CREATE (POST)
        [HttpPost]
        public async Task<ActionResult<ProdukReadDto>> CreateProduk([FromBody] ProdukCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kategori = await _context.Kategori.FindAsync(dto.KategoriId);
            if (kategori == null)
                return BadRequest(new { message = $"Kategori dengan ID {dto.KategoriId} tidak ditemukan." });

            var produk = new Produk
            {
                Nama = dto.Nama,
                Harga = dto.Harga,
                KategoriId = dto.KategoriId
            };

            _context.Produk.Add(produk);
            await _context.SaveChangesAsync();

            var result = new ProdukReadDto
            {
                Id = produk.Id,
                Nama = produk.Nama,
                Harga = produk.Harga,
                KategoriId = produk.KategoriId,
                KategoriNama = kategori.Nama
            };

            return CreatedAtAction(nameof(GetProdukById), new { id = produk.Id }, result);
        }

        // ✅ READ ALL (GET)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAllProduk()
        {
            var data = await _context.Produk
                .Include(p => p.Kategori)
                .Select(p => new
                {
                    p.Id,
                    p.Nama,
                    p.Harga,
                    p.KategoriId,
                    KategoriNama = p.Kategori != null ? p.Kategori.Nama : "(Tidak ada)"
                })
                .ToListAsync();

            return Ok(data);
        }

        // ✅ READ BY ID (GET/{id})
        [HttpGet("{id:int}")]
        public async Task<ActionResult<object>> GetProdukById(int id)
        {
            var produk = await _context.Produk
                .Include(p => p.Kategori)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produk == null)
                return NotFound(new { message = $"Produk dengan ID {id} tidak ditemukan." });

            return new
            {
                produk.Id,
                produk.Nama,
                produk.Harga,
                produk.KategoriId,
                KategoriNama = produk.Kategori?.Nama
            };
        }

        // ✅ UPDATE (PUT)
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduk(int id, [FromBody] ProdukUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produk = await _context.Produk.FindAsync(id);
            if (produk == null)
                return NotFound(new { message = $"Produk dengan ID {id} tidak ditemukan." });

            var kategori = await _context.Kategori.FindAsync(dto.KategoriId);
            if (kategori == null)
                return BadRequest(new { message = $"Kategori dengan ID {dto.KategoriId} tidak ditemukan." });

            produk.Nama = dto.Nama;
            produk.Harga = dto.Harga;
            produk.KategoriId = dto.KategoriId;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Produk berhasil diperbarui.",
                produk.Id,
                produk.Nama,
                produk.Harga,
                produk.KategoriId,
                KategoriNama = kategori.Nama
            });
        }

        // ✅ DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduk(int id)
        {
            var produk = await _context.Produk.FindAsync(id);
            if (produk == null)
                return NotFound(new { message = $"Produk dengan ID {id} tidak ditemukan." });

            _context.Produk.Remove(produk);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Produk dengan ID {id} berhasil dihapus." });
        }
    }
}
