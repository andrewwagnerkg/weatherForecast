using BLL.Services.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ForecastApp.Controllers
{
    public class LongTimeForecastController : BaseApiController
    {
        private readonly ILongTimeForecastService _forecastService;

        public LongTimeForecastController(ILongTimeForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        public Task<LongTimeForecastDto> Get()
        {
            return _forecastService.GetForecastAsync();
        }
    }
}
