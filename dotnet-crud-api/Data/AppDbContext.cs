using dotnet_crud_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnet_crud_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Produk> Produk { get; set; }
        public DbSet<Kategori> Kategori { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Atur precision harga biar gak warning
            modelBuilder.Entity<Produk>()
                .Property(p => p.Harga)
                .HasPrecision(18, 2);

            // Seed data kategori default
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori { Id = 1, Nama = "Umum" },
                new Kategori { Id = 2, Nama = "Elektronik" },
                new Kategori { Id = 3, Nama = "Buku" }
            );
        }
    }
}
