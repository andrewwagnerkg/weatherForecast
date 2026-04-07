using BLL.Services.Implimentations;
using BLL.Services.Interfaces;
using WeatherAPI_CSharp;

namespace ForecastApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "CORS",
                    policy =>
                    {
                        policy.AllowAnyOrigin() //Not recomended in production, but for testing purposes it's fine
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });


            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();


            builder.Services.AddSingleton<SettingsService>(_ => new SettingsService(builder.Configuration));
            builder.Services.AddSingleton<APIClient>(x =>
            {
                var settings = x.GetRequiredService<SettingsService>();
                return new APIClient(settings.GetApiKey());
            });
            builder.Services.AddTransient<IForecastService, ForecastService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("CORS");
            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
