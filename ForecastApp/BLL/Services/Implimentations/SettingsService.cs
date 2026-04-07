using Microsoft.Extensions.Configuration;

namespace BLL.Services.Implimentations
{
    public class SettingsService
    {
        IConfigurationManager _configurationManager;

        public SettingsService(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public string GetApiKey()
        {
            return _configurationManager.GetValue<string>("WeatherApiKey");
        }

        public string GetCity()
        {
            return _configurationManager.GetValue<string>("WeatherApiCity");
        }

        public string GetDays()
        {
            return _configurationManager.GetValue<int>("ForecastDaysCount").ToString();
        }

        public string GetCurrentQueryString() => $"current.json?key={GetApiKey()}&q={GetCity()}";

        public string GetForecastQueryString() => $"forecast.json?key={GetApiKey()}&q={GetCity()}&days={GetDays()}";
    }
}
