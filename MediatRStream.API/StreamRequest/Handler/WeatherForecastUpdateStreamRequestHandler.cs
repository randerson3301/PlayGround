using MediatR;

namespace MediatRStream.API.StreamRequest.Handler
{
    public class WeatherForecastUpdateStreamRequestHandler : IStreamRequestHandler<WeatherForecastUpdateStreamRequest, WeatherForecast>
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async IAsyncEnumerable<WeatherForecast> Handle(WeatherForecastUpdateStreamRequest request, 
            CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000, cancellationToken);

                yield return new WeatherForecast
                {
                    Date = DateTime.Now,
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                    TemperatureC = Random.Shared.Next(-20, 55),
                };
            }
        }
    }
}
