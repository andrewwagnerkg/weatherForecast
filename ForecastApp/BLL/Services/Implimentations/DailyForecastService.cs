using BLL.Services.Interfaces;
using DTO;

namespace BLL.Services.Implimentations
{
    public class DailyForecastService : IDailyForecastService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DailyForecastService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<DailyForecastDto> GetDailyForecastAsync(string city)
        {
            var client = _httpClientFactory.CreateClient("WeatherApiClient");





            return new DailyForecastDto
            {

            };
        }
    }
}
