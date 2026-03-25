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

            _db.WeatherHistories.Add(history);
            await _db.SaveChangesAsync();

            return Page();
        }
    }
}