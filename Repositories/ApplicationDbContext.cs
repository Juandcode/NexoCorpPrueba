using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

// public class Producto
// {
//     [Key]
//     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//     public Guid IdProducto { get; set; }
//
//     public string Nombre { get; set; } = string.Empty;
//     public decimal Costo { get; set; }
//     public decimal Precio => Costo * (1 + 50 / 100);
//     public int Stock { get; set; }
//     public bool Activo { get; set; }
//     public DateTime FechaVencimiento { get; set; }
//     public string Observaciones { get; set; } = string.Empty;
// }

// DbContext
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public ApplicationDbContext()
    {
    }

    //public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<ExpProductos> ExpProductos { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<ProductosCategorias> ProductosCategorias { get; set; }
    public DbSet<TiposProductos> TiposProductos { get; set; }
    public DbSet<CodigosBarras> CodigosBarras { get; set; }
    public DbSet<ErpProductos> ErpProductos { get; set; }
    public DbSet<VentasExpress> VentasExpress { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Solo se usa en tiempo de diseño (migraciones)
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=Nexocorp;MultipleActiveResultSets=True;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuraciones adicionales del modelo
        /*modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();*/

        //modelBuilder.Entity<ExpProductos>(entity => { entity.Ignore(p => p.Precio); });

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

                // Configuración simple - relación con padre
                entity.HasOne(c => c.CategoriaPadre)
                    .WithMany()// Sin navegación inversa
                    .HasForeignKey(c => c.IdCategoriaPadre)
                    .IsRequired(false)// Opcional
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