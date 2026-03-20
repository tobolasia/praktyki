using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private readonly string apiKey = "e08d15f0e41e9714f90499b2690e8060";

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetWeather_Click(object sender, EventArgs e)
        {
            string city = txtCity.Text.Trim();

            if (string.IsNullOrWhiteSpace(city))
            {
                MessageBox.Show("Wpisz nazwę miasta.");
                return;
            }

            try
            {
                var weather = await GetWeatherAsync(city);
                lblResult.Text = weather;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd pobierania danych: " + ex.Message);
            }
        }

        private async Task<string> GetWeatherAsync(string city)
        {
            string url =
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=pl";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                JObject json = JObject.Parse(response);

                string name = json["name"]?.ToString();
                string description = json["weather"]?[0]?["description"]?.ToString();
                string temp = json["main"]?["temp"]?.ToString();
                string humidity = json["main"]?["humidity"]?.ToString();
                string wind = json["wind"]?["speed"]?.ToString();

                return
                    $"Miasto: {name}\n" +
                    $"Temperatura: {temp} °C\n" +
                    $"Opis: {description}\n" +
                    $"Wilgotność: {humidity}%\n" +
                    $"Wiatr: {wind} m/s";
            }
        }
    }
}
