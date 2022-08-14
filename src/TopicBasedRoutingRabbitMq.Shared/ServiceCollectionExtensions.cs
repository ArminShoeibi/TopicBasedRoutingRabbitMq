using EasyNetQ;
using EasyNetQ.DI;
using Microsoft.Extensions.DependencyInjection;

namespace TopicBasedRoutingRabbitMq.Shared;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEasyNetQ(this IServiceCollection services)
    {
        services.RegisterEasyNetQ("host=localhost;port=5672;virtualHost=/;username=guest;password=guest;requestedHeartbeat=25", serviceRegister =>
        {
            serviceRegister.EnableNewtonsoftJson();
        });
        return services;
    }
}
