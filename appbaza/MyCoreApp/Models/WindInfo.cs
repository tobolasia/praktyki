using System.Text.Json.Serialization;

namespace MyCoreApp.Models
{
    public class WindInfo
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        [JsonPropertyName("deg")]
        public int Deg { get; set; }
    }
}