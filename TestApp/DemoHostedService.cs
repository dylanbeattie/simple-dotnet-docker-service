// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class DemoHostedService : IHostedService {
    private readonly ILogger<DemoHostedService> logger;
    private Timer? timer = null;
    private int count = 0;
    private HttpClient client = new HttpClient();
    public DemoHostedService(ILogger<DemoHostedService> logger) {
        this.logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken) {
        logger.LogInformation("Starting DemoHostedService");
        var initialDelay = TimeSpan.FromSeconds(2);
        var interval = TimeSpan.FromSeconds(2);
        object? state = null;
        timer = new Timer(DoWork, state, initialDelay, interval);
        return Task.CompletedTask;
    }

    private async void DoWork(object? state) {
        Interlocked.Increment(ref count);
        logger.LogInformation($"Sending HTTP request {count}");
        var json = await client.GetStringAsync("https://httpbin.org/get");
        logger.LogInformation(json);
    }

    public Task StopAsync(CancellationToken cancellationToken) {
        logger.LogInformation("Stopping DemoHostedService");
        return Task.CompletedTask;
    }

    public void Dispose() {
        timer?.Dispose();
    }
}

