using System.Reflection;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;

namespace TopicBasedRoutingRabbitMq.Consumer1;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IBus _bus;

    public Worker(ILogger<Worker> logger, IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        AutoSubscriber autoSubscriber = new(_bus, "TestPrefix");
        await autoSubscriber.SubscribeAsync(Assembly.GetExecutingAssembly().GetTypes(), stoppingToken);
    }
}
