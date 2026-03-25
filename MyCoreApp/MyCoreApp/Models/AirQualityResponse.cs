using System.Text.Json.Serialization;

namespace MyCoreApp.Models
{
    public class AirQualityResponse
    {
        [JsonPropertyName("list")]
        public List<AirQualityItem> List { get; set; }
    }

    public class AirQualityItem
    {
        [JsonPropertyName("main")]
        public AirQualityIndex Main { get; set; }

        [JsonPropertyName("components")]
        public AirQualityComponents Components { get; set; }
    }

    public class AirQualityIndex
    {
        [JsonPropertyName("aqi")]
        public int Aqi { get; set; }
    }

    public class AirQualityComponents
    {
        [JsonPropertyName("pm2_5")]
        public double Pm2_5 { get; set; }

        [JsonPropertyName("pm10")]
        public double Pm10 { get; set; }

        [JsonPropertyName("no2")]
        public double No2 { get; set; }

        [JsonPropertyName("so2")]
        public double So2 { get; set; }

        [JsonPropertyName("o3")]
        public double O3 { get; set; }

        [JsonPropertyName("co")]
        public double Co { get; set; }
    }
}
