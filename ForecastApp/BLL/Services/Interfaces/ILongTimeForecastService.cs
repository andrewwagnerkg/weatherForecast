using DTO;

namespace BLL.Services.Interfaces
{
    public interface ILongTimeForecastService
    {
        Task<LongTimeForecastDto> GetForecastAsync();
    }
}
