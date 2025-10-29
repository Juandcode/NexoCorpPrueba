using Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _transaction;

        public IGenericRepository<ExpProductos> ExpProductos { get; }
        public IGenericRepository<ErpProductos> ErpProductos { get; }
        public IGenericRepository<CodigosBarras> CodigosBarras { get; }
        public IGenericRepository<Categorias> Categorias { get; }
        public IGenericRepository<ProductosCategorias> ProductosCategorias { get; }
        public IGenericRepository<VentasExpress> VentasExpress { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ExpProductos = new GenericRepository<ExpProductos>(_context);
            ErpProductos = new GenericRepository<ErpProductos>(_context);
            CodigosBarras = new GenericRepository<CodigosBarras>(_context);
            Categorias = new GenericRepository<Categorias>(_context);
            ProductosCategorias = new GenericRepository<ProductosCategorias>(_context);
            VentasExpress = new GenericRepository<VentasExpress>(_context);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}