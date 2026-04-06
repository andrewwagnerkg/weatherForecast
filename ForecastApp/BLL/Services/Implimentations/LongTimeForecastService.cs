using BLL.Services.Interfaces;
using DTO;

namespace BLL.Services.Implimentations
{
    public class LongTimeForecastService : ILongTimeForecastService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LongTimeForecastService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<LongTimeForecastDto> GetForecastAsync(string city, int countDays)
        {
            var client = _httpClientFactory.CreateClient("WeatherApiClient");

            return new LongTimeForecastDto
            {

            };
        }
    }
}
