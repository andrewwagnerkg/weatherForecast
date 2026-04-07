using BLL.Services.Interfaces;
using DTO;
using WeatherAPI_CSharp;

namespace BLL.Services.Implimentations
{
    public class ForecastService(SettingsService settingsService, APIClient weatherClient) : IForecastService
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
                var current = await weatherClient.GetWeatherCurrentAsync(settingsService.GetCity());

                return new CurrentLookupDto
                {
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
                var hourly = (await weatherClient.GetWeatherForecastHourlyAsync(settingsService.GetCity(), 48))
                    .Where(x => x.Date >= DateTime.Now)
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
    }
}
