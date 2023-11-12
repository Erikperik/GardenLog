using Azure;
using GardenLog.Controllers;
using GardenLog.Models;
using System.Text.Json;

namespace GardenLog.Services
{
    public class JsonFileWeatherService
    {
        // Summary:
        // API request for weather data. Stored in a Weatherforecast obj. Data formatted before return.
        public async Task<Weatherforecast> GetForecast()
        {
            var client = new HttpClient();
            var body = "";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.open-meteo.com/v1/forecast?latitude=57.9333&longitude=14.45&daily=weathercode,temperature_2m_max,temperature_2m_min,precipitation_sum,windspeed_10m_max,windgusts_10m_max,winddirection_10m_dominant&current_weather=true&windspeed_unit=ms&timezone=Europe%2FBerlin"),
                Headers =
            {
            { "X-RapidAPI-Key", "750095e95dmsha4cbd4165b0ce58p12b294jsnd4ffa4d353ca" },
            { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }

            Weatherforecast? WeatherForecast = JsonSerializer.Deserialize<Weatherforecast>(body);

            // Formattning
            for (int i = 0; i < WeatherForecast.daily_data.time.Length; i++)
            {
                WeatherForecast.daily_data.time[i] = WeatherForecast.daily_data.time[i].Replace('T', ' ');
            }
            return WeatherForecast;
        }
    }
}
