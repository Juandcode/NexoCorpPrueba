using Domain;
using Repositories;

namespace Services;

/// <summary>
/// Pos Express
/// </summary>
public class ServicePosExpress : IServicePosExpress
{
    private readonly IUnitOfWork _unitOfWork;

    public ServicePosExpress(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //Pregunta 1
    public async Task<ExpProductos> RegistrarNuevoProductoErp()
    {
        await _unitOfWork.BeginTransactionAsync();

        decimal costo = 20;
        decimal precio = costo / 2;
        ExpProductos producto = new ExpProductos()
        {
            Activo = true,
            Nombre = "Producto",
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

    //pregunta 2
    //Registro Asignación de Códigos de Barras
    public async Task RegistroCodigoBarras(ExpProductos expProducto)
    {
        await _unitOfWork.BeginTransactionAsync();
        CodigosBarras codigosBarras = new CodigosBarras()
        {
            IdProducto = expProducto.IdProducto,
            Activo = true,
        };

        await _unitOfWork.CodigosBarras.AddAsync(codigosBarras);

        await _unitOfWork.CommitTransactionAsync();
    }

    //Pregunta 3
    //Registro de Asignación de Categorías de Productos
    public async Task RegistroCategoriasProductos(ExpProductos expProducto)
    {
        await _unitOfWork.BeginTransactionAsync();

        Categorias categoria = new Categorias()
        {
            Descripcion = "Categoria 1",
        };
        await _unitOfWork.Categorias.AddAsync(categoria);

        await _unitOfWork.CommitAsync();

        ProductosCategorias productosCategorias = new ProductosCategorias()
        {
            IdProducto = expProducto.IdProducto,
            IdCategoria = categoria.IdCategoria,
        };
        await _unitOfWork.ProductosCategorias.AddAsync(productosCategorias);

        await _unitOfWork.CommitAsync();

        await _unitOfWork.CommitTransactionAsync();
    }

    //Pregunta 4
    //Registro venta
    public async Task RegistroVenta(ExpProductos expProducto)
    {
        await _unitOfWork.BeginTransactionAsync();

        //regla de negocio 2
        var uniqueProducto = expProducto.ErpProductos.UniqueCodigo;

        //regla de negocio 3
        var allCategoriasProducto = (await _unitOfWork.ProductosCategorias.GetAllAsync()).ToList();

        var categoriasProducto = allCategoriasProducto.Where(catProd => catProd.IdProducto == expProducto.IdProducto);

        decimal descuento = 0;
        if (categoriasProducto.Count() == 1)
        {
            descuento = expProducto.Precio * 0.3m;
        }


        int stockaVender = 3;
        //regla de negocio 4
        if (expProducto.ErpProductos.Stock <= stockaVender) throw new Exception("No hay stock suficiente");


        var total = (expProducto.Precio * stockaVender) - descuento;

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

        expProducto.ErpProductos.Stock -= stockaVender;

        _unitOfWork.ExpProductos.Update(expProducto);

        await _unitOfWork.CommitTransactionAsync();
    }
}