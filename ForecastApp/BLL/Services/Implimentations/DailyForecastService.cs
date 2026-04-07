using BLL.Services.Interfaces;
using DTO;
using Newtonsoft.Json;

namespace BLL.Services.Implimentations
{
    public class DailyForecastService : IDailyForecastService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly SettingsService _settingsService;

        public DailyForecastService(IHttpClientFactory httpClientFactory, SettingsService settingsService)
        {
            _httpClientFactory = httpClientFactory;
            _settingsService = settingsService;
        }

        public async Task<DailyForecastDto> GetDailyForecastAsync()
        {
            var client = _httpClientFactory.CreateClient("WeatherApiClient");

            var responseForecast = await client.GetStringAsync(_settingsService.GetForecastQueryString());

            var forecastDto = JsonConvert.DeserializeObject<ExternalForecastDto>(responseForecast);

            return new DailyForecastDto
            {

            };
        }
    }
}
