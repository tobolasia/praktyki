using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyCoreApp.Models;
using MyCoreApp.Services;
using MyCoreApp.Data;

namespace MyCoreApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WeatherService _weatherService;
        private readonly AppDbContext _db;

        public IndexModel(WeatherService weatherService, AppDbContext db)
        {
            _weatherService = weatherService;
            _db = db;
        }

        [BindProperty]
        public string City { get; set; }

        public WeatherResponse? Weather { get; set; }
        public ForecastResponse? Forecast { get; set; }
        public AirQualityResponse? AirQuality { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (string.IsNullOrWhiteSpace(City))
            {
                ErrorMessage = "Podaj nazwę miasta.";
                return Page();
            }

            Weather = await _weatherService.GetWeatherAsync(City);

            Forecast = await _weatherService.GetForecastAsync(City);

            if (Weather == null)
            {
                ErrorMessage = "Nie znaleziono miasta lub wystąpił błąd API.";
                return Page();
            }

            var history = new WeatherHistory
            {
                City = Weather.Name,
                Temperature = Weather.Main.Temp,
                Description = Weather.Weather[0].Description,
                Humidity = Weather.Main.Humidity,
                WindSpeed = Weather.Wind.Speed,
                CreatedAt = DateTime.UtcNow
            };

            if (Weather != null)
            {
                AirQuality = await _weatherService.GetAirQualityAsync(
                    Weather.Coord.Lat,
                    Weather.Coord.Lon
                );
            }

            _db.WeatherHistories.Add(history);
            await _db.SaveChangesAsync();

            return Page();
        }
    }
}