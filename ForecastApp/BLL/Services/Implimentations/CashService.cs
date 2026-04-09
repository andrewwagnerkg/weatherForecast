using BLL.Services.Interfaces;
using DAL;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BLL.Services.Implimentations
{
    public class CashService : ICashService
    {
        private readonly ApplicationDataContext _context;

        public CashService(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<bool> HasCashRecordByLastDateUpdateAsync(string lastDataUpdate)
        {
            return await _context.ForecastCashes.AnyAsync(x => x.LastUpdatedDateTime == lastDataUpdate);
        }

        public async Task AddCashRecordAsync(ForecastDto cash)
        {
            await _context.ForecastCashes.AddAsync(new ForecastCash
            {
                LastUpdatedDateTime = cash.Current.LastUpdated,
                Forecast = JsonConvert.SerializeObject(cash)
            });
            await _context.SaveChangesAsync();
        }

        public async Task<ForecastDto> GetForecastDtoByLastDateUpdateAsync(string lastDataUpdate)
        {
            var cashRecord = await _context.ForecastCashes.FirstOrDefaultAsync(x => x.LastUpdatedDateTime == lastDataUpdate);
            if (cashRecord == null)
            {
                throw new Exception("No saved object");
            }

            return JsonConvert.DeserializeObject<ForecastDto>(cashRecord.Forecast) ?? new ForecastDto();
        }
    }
}
