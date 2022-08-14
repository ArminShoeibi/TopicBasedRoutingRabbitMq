using TopicBasedRoutingRabbitMq.Consumer1;
using TopicBasedRoutingRabbitMq.Shared;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddEasyNetQ();
    })
    .Build();

await host.RunAsync();
