using DTO;

namespace BLL.Services.Interfaces
{
    public interface ICashService
    {
        Task<bool> HasCashRecordByLastDateUpdateAsync(string lastDataUpdate);
        Task AddCashRecordAsync(ForecastDto cash);
        Task<ForecastDto> GetForecastDtoByLastDateUpdateAsync(string lastDataUpdate);
    }
}
