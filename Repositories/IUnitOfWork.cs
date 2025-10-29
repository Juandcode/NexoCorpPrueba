using Domain;

namespace Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ExpProductos> ExpProductos { get; }
        IGenericRepository<ErpProductos> ErpProductos { get; }
        IGenericRepository<CodigosBarras> CodigosBarras { get; }
        IGenericRepository<Categorias> Categorias { get; }
        IGenericRepository<ProductosCategorias> ProductosCategorias { get; }
        IGenericRepository<VentasExpress> VentasExpress { get; }

        Task<int> SaveChangesAsync();
        Task CommitAsync();
        
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}