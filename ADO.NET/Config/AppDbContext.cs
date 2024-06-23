using Fujitsu.ADO.NET.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Gudang> Gudangs { get; set; }
    public DbSet<Barang> Barangs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Barang>()
        //     .Property(b => b.Kode_Gudang_ID)
        //     .IsRequired();

        // modelBuilder.Entity<Barang>()
        //     .HasOne(b => b.Gudang)
        //     .WithMany()
        //     .HasForeignKey(b => b.Kode_Gudang_ID)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
