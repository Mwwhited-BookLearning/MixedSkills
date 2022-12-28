using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace DataViewer.Cli
{

    public class ConsoleAppService : IHostedService
    {
        private readonly ILogger _log;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly SerialMonitorOptions _config;

        public ConsoleAppService(
            ILogger<ConsoleAppService> log,
            IHostApplicationLifetime appLifetime,
            IOptions<SerialMonitorOptions> options
            )
        {
            _log = log;
            _appLifetime = appLifetime;
            _config = options.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var port = new SerialPort(_config.PortName, _config.BaudRate, _config.Parity, _config.DataBits);

            port.Open();

            while (port.IsOpen)
            {
                var line = port.ReadLine();
                _log.LogInformation(line);
            }

            //var ports = SerialPort.GetPortNames();
            //foreach (var port in ports)
            //{
            //    _log.LogInformation($"{port}");
            //}

            await Task.Yield();
        }

        public Task StopAsync(CancellationToken cancellationToken) =>
            Task.CompletedTask;
    }
}
