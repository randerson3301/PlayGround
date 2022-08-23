using MediatR;

namespace MediatRStream.API.StreamRequest
{    
    public class WeatherForecastUpdateStreamRequest : IStreamRequest<WeatherForecast>
    {
        public WeatherForecastUpdateStreamRequest(string city)
        {
            City = city;
        }

        public string City { get; }
    }
}
