using BLL.Services.Interfaces;
using DTO;
using WeatherAPI_CSharp;

namespace BLL.Services.Implimentations
{
    public class ForecastService(SettingsService settingsService, APIClient weatherClient, ICashService cashService) : IForecastService
    {
        public async Task<DailyLookupDto> GetDailyForecastAsync()
        {
            try
            {
                var daily = await weatherClient.GetWeatherForecastDailyAsync(settingsService.GetCity(), 3);

                return new DailyLookupDto()
                {
                    Status = 200,
                    Message = "Ok",
                    Data = daily.Select(x => new DailyDto
                    {
                        Date = x.Date,
                        ConditionIconUrl = x.ConditionIconUrl,
                        ConditionText = x.ConditionText,
                        AvgTemperatureCelsius = x.AvgTemperatureCelsius,
                        MaxTemperatureCelsius = x.MaxTemperatureCelsius,
                        MinTemperatureCelsius = x.MinTemperatureCelsius
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                return DailyLookupDto.Error(ex.Message);
            }
        }

        public async Task<CurrentLookupDto> GetCurrentForecastAsync()
        {
            try
            {
                var cityName = settingsService.GetCity();
                var current = await weatherClient.GetWeatherCurrentAsync(cityName);

                return new CurrentLookupDto
                {
                    City = cityName,
                    Status = 200,
                    Message = "Ok",
                    ConditionIconUrl = current.ConditionIconUrl,
                    ConditionText = current.ConditionText,
                    FeelsLikeCelsius = current.FeelsLikeCelsius,
                    TemperatureCelsius = current.TemperatureCelsius,
                    LastUpdated = current.LastUpdated
                };
            }
            catch (Exception e)
            {
                return new CurrentLookupDto
                {
                    Status = 500,
                    Message = e.Message
                };
            }

        }

        public async Task<HourlyLookupDto> GetHourlyForecastAsync()
        {
            try
            {
                var hourly = (await weatherClient.GetWeatherForecastHourlyAsync(settingsService.GetCity(), settingsService.GetHoursCount()))
                    .Where(x => x.Date >= TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, settingsService.GetTimeZone()))
                    .Select(x => new HourDto
                    {
                        Date = x.Date,
                        ConditionIconUrl = x.ConditionIconUrl,
                        ConditionText = x.ConditionText,
                        TemperatureCelsius = x.TemperatureCelsius
                    });

                return new HourlyLookupDto
                {
                    Status = 200,
                    Data = hourly.ToList()
                };
            }
            catch (Exception e)
            {
                return HourlyLookupDto.Error(e.Message);
            }

        }

        public async Task<ForecastDto> GetCashedForecastAsync()
        {

            try
            {
                var current = await GetCurrentForecastAsync();
                var hasCash = await cashService.HasCashRecordByLastDateUpdateAsync(current.LastUpdated);
                if (!hasCash)
                {
                    await cashService.AddCashRecordAsync(new ForecastDto
                    {
                        Current = current,
                        Hourly = await GetHourlyForecastAsync(),
                        Daily = await GetDailyForecastAsync()
                    });
                }

                var cashed = await cashService.GetForecastDtoByLastDateUpdateAsync(current.LastUpdated);
                return cashed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ;
            }

            return new ForecastDto();
        }
    }
}
