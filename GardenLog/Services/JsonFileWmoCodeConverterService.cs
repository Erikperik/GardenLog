using GardenLog.Controllers;
using GardenLog.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json;

namespace GardenLog.Services
{
    // Summary:
    // Fetches JSON file with informatin about WMO-codes and weather descriptions
    public class JsonFileWmoCodeConverterService
    {
        public JsonFileWmoCodeConverterService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "weather.json");
        public Weatherdescription GetWeatherDescription()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            Weatherdescription? WeatherDescription = JsonSerializer.Deserialize<Weatherdescription>(jsonFileReader.ReadToEnd());

            return WeatherDescription;
        }
    }
}
