// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) => {
        services.AddHostedService<DemoHostedService>();
    })
    .UseSerilog(ConfigureLogger)    
    .Build();

await host.RunAsync();

static void ConfigureLogger(HostBuilderContext host, LoggerConfiguration log) {
    log.MinimumLevel.Debug();
    log.WriteTo.Console();
    log.Enrich.WithProcessName();
}

