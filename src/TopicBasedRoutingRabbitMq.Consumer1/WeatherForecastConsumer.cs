using EasyNetQ.AutoSubscribe;
using TopicBasedRoutingRabbitMq.Shared;

namespace TopicBasedRoutingRabbitMq.Consumer1;
internal class WeatherForecastConsumer : IConsumeAsync<WeatherForecast>
{
    public async Task ConsumeAsync(WeatherForecast message, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1000);
        Console.WriteLine(message);
    }
}
