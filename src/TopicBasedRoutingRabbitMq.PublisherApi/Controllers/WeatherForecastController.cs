using System;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;

namespace TopicBasedRoutingRabbitMq.PublisherApi.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IBus _bus;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> PublishWeatherForecast(CancellationToken cancellationToken)
    {
        await _bus.PubSub.PublishAsync(new WeatherForecast
        {
            Date = DateTime.Now.AddDays(Random.Shared.Next(1, 10)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }, cancellationToken);
        return Accepted();
    }



    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
