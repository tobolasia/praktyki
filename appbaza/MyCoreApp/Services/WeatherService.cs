using System.Text.Json;
using MyCoreApp.Models;

namespace MyCoreApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["OpenWeather:ApiKey"];
        }

        public async Task<WeatherResponse?> GetWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return null;

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric&lang=pl";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<WeatherResponse>(json);

            if (result == null ||
                result.Main == null ||
                result.Weather == null ||
                result.Weather.Length == 0 ||
                result.Wind == null)
            {
                return null;
            }

            return result;
        }
    }
}