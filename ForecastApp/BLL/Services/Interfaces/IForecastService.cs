using DTO;

namespace BLL.Services.Interfaces
{
    public interface IForecastService
    {
        Task<DailyLookupDto> GetDailyForecastAsync();
        Task<CurrentLookupDto> GetCurrentForecastAsync();
        Task<HourlyLookupDto> GetHourlyForecastAsync();
        Task<ForecastDto> GetCashedForecastAsync();
    }
}
