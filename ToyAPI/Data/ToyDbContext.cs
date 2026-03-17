using Microsoft.EntityFrameworkCore;
using ToyAPI.Models;

namespace ToyAPI.Data;

public class ToyDbContext : DbContext
{
    public ToyDbContext(DbContextOptions<ToyDbContext> options) : base(options)
    {
    }

    public DbSet<Brinquedo> Brinquedos => Set<Brinquedo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brinquedo>(entity =>
        {
            entity.HasKey(e => e.IdBrinquedo);
            entity.Property(e => e.NomeBrinquedo).HasMaxLength(120).IsRequired();
            entity.Property(e => e.TipoBrinquedo).HasMaxLength(60).IsRequired();
            entity.Property(e => e.Classificacao).HasMaxLength(20).IsRequired();
            entity.Property(e => e.Tamanho).HasMaxLength(30).IsRequired();
            entity.Property(e => e.Preco).HasColumnType("decimal(10,2)");
        });
    }
}
