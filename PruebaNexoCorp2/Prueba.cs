using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PruebaNexoCorp2
{
    public class Prueba : IHostedService
    {
        public Prueba(ILogger<Prueba> logger)
        {
            _logger = logger;
        }

        private readonly ILogger<Prueba> _logger;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando servicio...");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deteniendo servicio...");
            return Task.CompletedTask;
        }
    }
}