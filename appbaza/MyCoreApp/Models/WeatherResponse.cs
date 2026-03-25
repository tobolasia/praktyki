using System.Text.Json.Serialization;

namespace MyCoreApp.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weather")]
        public WeatherInfo[] Weather { get; set; }

        [JsonPropertyName("main")]
        public MainInfo Main { get; set; }

        [JsonPropertyName("wind")]
        public WindInfo Wind { get; set; }
    }
}