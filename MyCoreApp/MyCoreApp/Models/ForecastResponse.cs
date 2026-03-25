using System.Text.Json.Serialization;

namespace MyCoreApp.Models
{
    public class ForecastResponse
    {
        [JsonPropertyName("list")]
        public List<ForecastItem> List { get; set; }

        [JsonPropertyName("city")]
        public ForecastCity City { get; set; }
    }

    public class ForecastItem
    {
        [JsonPropertyName("dt_txt")]
        public string DtTxt { get; set; }

        [JsonPropertyName("main")]
        public MainInfo Main { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherInfo> Weather { get; set; }

        [JsonPropertyName("wind")]
        public WindInfo Wind { get; set; }
    }

    public class ForecastCity
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}