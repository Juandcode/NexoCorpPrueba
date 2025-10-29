using Domain;
using Repositories;

namespace Services
{
    /// <summary>
    /// Estrategia Ganamax
    /// </summary>
    public class ServiceGanamaxEstrategia : IServiceGanamaxEstrategia
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceGanamaxEstrategia(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Pregunta 1
        public async Task<ExpProductos> RegistrarNuevoProductoErp()
        {
            await _unitOfWork.BeginTransactionAsync();

            decimal costo = 20;
            decimal precio = costo * 0.80m;
            ExpProductos producto = new ExpProductos()
            {
                Activo = true,
                Nombre = "Producto Ganamax",
                Observaciones = "Nada",
                Precio = precio,
                FechaVencimiento = DateTime.Now.AddMonths(10),
            };

            await _unitOfWork.ExpProductos.AddAsync(producto);

            await _unitOfWork.CommitAsync();

            ErpProductos erpProductos = new ErpProductos()
            {
                IdProducto = producto.IdProducto,
                Costo = costo,
                Stock = 20,
                FechaRegistro = DateTime.Now,
            };

            await _unitOfWork.ErpProductos.AddAsync(erpProductos);

            await _unitOfWork.CommitAsync();

            await _unitOfWork.CommitTransactionAsync();

            return producto;
        }
        
        public async Task RegistroVenta(ExpProductos expProducto)
        {
            await _unitOfWork.BeginTransactionAsync();

            var uniqueProducto = expProducto.ErpProductos.UniqueCodigo;

            // regla de negocio 3
            var allCategoriasProducto = (await _unitOfWork.ProductosCategorias.GetAllAsync()).ToList();

            var categoriasProducto =
                allCategoriasProducto.Where(catProd => catProd.IdProducto == expProducto.IdProducto);

            decimal descuento = 0;
            if (categoriasProducto.Count() == 1)
            {
                descuento = expProducto.Precio * 0.10m;
            }

            var stockaVender = 3;

            var total = (expProducto.Precio * stockaVender) - descuento;

            // reglar de negocio 4
            if (expProducto.ErpProductos.Stock <= stockaVender) throw new Exception("No hay stock suficiente");


            VentasExpress ventasExpress = new VentasExpress()
            {
                IdProducto = expProducto.IdProducto,
                UniqueProducto = uniqueProducto,
                Precio = expProducto.Precio,
                Cantidad = stockaVender,
                Cliente = "Diego",
                Descuento = descuento,
                Fecha = DateTime.Now,
                Producto = expProducto.Nombre,
                Total = total,
            };
            await _unitOfWork.VentasExpress.AddAsync(ventasExpress);

            // deja un stock por encima de 10
            expProducto.ErpProductos.Stock = 11;

            _unitOfWork.ExpProductos.Update(expProducto);

            await _unitOfWork.CommitTransactionAsync();
        }
    }
}