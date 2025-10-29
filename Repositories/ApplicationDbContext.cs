using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public ApplicationDbContext()
    {
    }
    
    public DbSet<ExpProductos> ExpProductos { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<ProductosCategorias> ProductosCategorias { get; set; }
    public DbSet<TiposProductos> TiposProductos { get; set; }
    public DbSet<CodigosBarras> CodigosBarras { get; set; }
    public DbSet<ErpProductos> ErpProductos { get; set; }
    public DbSet<VentasExpress> VentasExpress { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=Nexocorp;MultipleActiveResultSets=True;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpProductos>()
            .HasOne(e => e.TiposProductos)
            .WithOne(t => t.ExpProductos)
            .HasForeignKey<ExpProductos>(e => e.IdTipoProducto);

        modelBuilder.Entity<ErpProductos>()
            .HasOne(e => e.ExpProductos)
            .WithOne(t => t.ErpProductos)
            .HasForeignKey<ErpProductos>(e => e.IdProducto);

        modelBuilder.Entity<CodigosBarras>()
            .HasOne(c => c.ExpProductos)
            .WithOne(e => e.CodigosBarras)
            .HasForeignKey<CodigosBarras>(e => e.IdProducto);

        modelBuilder.Entity<VentasExpress>()
            .HasOne(v => v.ExpProductos)
            .WithOne(e => e.VentasExpress)
            .HasForeignKey<VentasExpress>(e => e.IdProducto);

        modelBuilder.Entity<Categorias>(
            entity =>
            {
                entity.HasKey(c => c.IdCategoria);
                
                entity.HasOne(c => c.CategoriaPadre)
                    .WithMany()
                    .HasForeignKey(c => c.IdCategoriaPadre)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });


        modelBuilder.Entity<ProductosCategorias>()
            .HasOne(o => o.ExpProductos)
            .WithOne(p => p.ProductosCategoria)
            .HasForeignKey<ProductosCategorias>(o => o.IdProducto);// FK en Order

        modelBuilder.Entity<ProductosCategorias>()
            .HasOne(o => o.Categorias)
            .WithOne(p => p.ProductosCategoria)
            .HasForeignKey<ProductosCategorias>(o => o.IdCategoria);// FK en Order
    }
}