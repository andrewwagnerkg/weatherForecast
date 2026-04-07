using BLL.Services.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ForecastApp.Controllers
{
    public class ForecastController(IForecastService forecastService) : BaseApiController
    {
        [HttpGet("daily")]
        public Task<DailyLookupDto> GetDaily()
            => forecastService.GetDailyForecastAsync();

        [HttpGet("current")]
        public Task<CurrentLookupDto> GetCurrent()
        {
            return forecastService.GetCurrentForecastAsync();
        }

        [HttpGet("hourly")]
        public Task<HourlyLookupDto> GetHourly()
        {
            return forecastService.GetHourlyForecastAsync();
        }
    }
}
