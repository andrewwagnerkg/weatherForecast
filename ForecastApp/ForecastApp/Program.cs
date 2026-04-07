using BLL.Services.Implimentations;
using BLL.Services.Interfaces;

namespace ForecastApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient("WeatherApiClient", client =>
            {
                client.BaseAddress = new Uri("https://api.weatherapi.com/v1/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });


            builder.Services.AddSingleton<SettingsService>(_ => new SettingsService(builder.Configuration));
            builder.Services.AddTransient<IDailyForecastService, DailyForecastService>();
            builder.Services.AddTransient<ILongTimeForecastService, LongTimeForecastService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
