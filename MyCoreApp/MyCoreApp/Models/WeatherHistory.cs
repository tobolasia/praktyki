using System;

namespace MyCoreApp.Models
{
    public class WeatherHistory
    {
        public int Id { get; set; }
        public string City { get; set; }
        public float Temperature { get; set; }
        public string Description { get; set; }
        public int Humidity { get; set; }
        public float WindSpeed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}