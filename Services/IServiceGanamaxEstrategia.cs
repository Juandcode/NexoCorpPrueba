using Domain;

namespace Services
{
    public interface IServiceGanamaxEstrategia
    {
        Task<ExpProductos> RegistrarNuevoProductoErp();
        Task RegistroVenta(ExpProductos expProducto);
    }
}