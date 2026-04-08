using BLL.Services.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ForecastApp.Controllers
{
    public class ForecastController(IForecastService forecastService) : BaseApiController
    {
        [HttpGet("daily")]
        public async Task<DailyLookupDto> GetDaily()
            => (await forecastService.GetCashedForecastAsync()).Daily;

        [HttpGet("current")]
        public async Task<CurrentLookupDto> GetCurrent()
        {
            return (await forecastService.GetCashedForecastAsync()).Current;
        }

        [HttpGet("hourly")]
        public async Task<HourlyLookupDto> GetHourly()
        {
            return (await forecastService.GetCashedForecastAsync()).Hourly;
        }

        [HttpGet("common")]
        public async Task<ForecastDto> GetCommonForecast()
        {
            return await forecastService.GetCashedForecastAsync();
        }
    }
}
