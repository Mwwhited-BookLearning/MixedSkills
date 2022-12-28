using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace DataViewer.Cli
{
    internal class Program
    {
        // https://dfederm.com/building-a-console-app-with-.net-generic-host
        static Task Main(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddHostedService<ConsoleAppService>();

                    services.AddOptions<SerialMonitorOptions>()
                            .Bind(context.Configuration.GetSection(SerialMonitorOptions.Section));
                })
            .RunConsoleAsync();
    }
}
