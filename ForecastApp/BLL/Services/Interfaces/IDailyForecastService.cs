using DTO;

namespace BLL.Services.Interfaces
{
    public interface IDailyForecastService
    {
        Task<DailyForecastDto> GetDailyForecastAsync(string city);
    }
}
