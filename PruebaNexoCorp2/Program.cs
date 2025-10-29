// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repositories;
using Services;


async Task InicializarDatosNormalAsync(IServiceProvider services)
{
    using var scope = services.CreateScope();
    IServicePosExpress servicio = scope.ServiceProvider.GetRequiredService<IServicePosExpress>();

    var producto = await servicio.RegistrarNuevoProductoErp();
    await servicio.RegistroCodigoBarras(producto);
    await servicio.RegistroCategoriasProductos(producto);
    await servicio.RegistroVenta(producto);
}

async Task InicializarDatosGanamaxAsync(IServiceProvider services)
{
    using var scope = services.CreateScope();
    IServiceGanamaxEstrategia servicio = scope.ServiceProvider.GetRequiredService<IServiceGanamaxEstrategia>();

    var producto = await servicio.RegistrarNuevoProductoErp();
    await servicio.RegistroVenta(producto);
}

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServicePosExpress, ServicePosExpress>();
builder.Services.AddScoped<IServiceGanamaxEstrategia, ServiceGanamaxEstrategia>();
var app = builder.Build();

Console.WriteLine("Seleccionar tipo, 1: normal, 2: Estrategia ganamax");

string? b1 = Console.ReadLine();
if (int.TryParse(b1, out int input))
{
    switch (input)
    {
        case 1:
            await InicializarDatosNormalAsync(app.Services);
            break;
        case 2:
            await InicializarDatosGanamaxAsync(app.Services);
            break;
        default:
            throw new ApplicationException("Tipo incorrecto.");
    }
}

app.Run();
