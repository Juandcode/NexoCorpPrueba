using Domain;

namespace Services
{
    public interface IServicePosExpress
    {
        Task<ExpProductos> RegistrarNuevoProductoErp();
        Task RegistroCodigoBarras(ExpProductos expProducto);
        Task RegistroCategoriasProductos(ExpProductos expProducto);
        Task RegistroVenta(ExpProductos expProducto);
    }
}