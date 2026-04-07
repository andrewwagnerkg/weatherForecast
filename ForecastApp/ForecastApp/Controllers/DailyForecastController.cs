using BLL.Services.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ForecastApp.Controllers
{
    public class DailyForecastController : BaseApiController
    {
        private readonly IDailyForecastService _dailyForecastService;

        public DailyForecastController(IDailyForecastService forecastService)
        {
            _dailyForecastService = forecastService;
        }

        [HttpGet]
        public Task<DailyForecastDto> Get()
        {
            return _dailyForecastService.GetDailyForecastAsync();
        }
    }
}
