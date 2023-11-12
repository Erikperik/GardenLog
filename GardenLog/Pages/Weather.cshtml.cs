using GardenLog.Models;
using GardenLog.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;

namespace GardenLog.Pages
{
    public class WeatherModel : PageModel
    {
        public JsonFileWeatherService WeatherService;
        public JsonFileWmoCodeConverterService CodeConverterService;
        public Weatherforecast? WeatherForecast { get; set; }
        public Weatherdescription? WeatherDescription { get; set; }
        public string? currentWeatherDescription { get; set; }
        public WeatherModel(
            JsonFileWeatherService weatherService,
            JsonFileWmoCodeConverterService codeConverterService)
        {
            WeatherService = weatherService;
            CodeConverterService = codeConverterService;
        }

        public void OnGet()
        {
            try
            {
                WeatherForecast = WeatherService.GetForecast().Result;
                WeatherDescription = CodeConverterService.GetWeatherDescription();
            }
            catch
            {
                Response.Redirect("/error");
            }

            for (int i = 0; i < WeatherDescription.description.wmocode.Length; i++)
            {
                var currentCode = new int();

                try
                {
                    currentCode = (int)WeatherForecast.current_weather.weathercode;
                }
                catch
                {
                    Response.Redirect("/error");
                    
                }

                if (currentCode == WeatherDescription.description.wmocode[i])
                {
                    currentWeatherDescription = WeatherDescription.description.descriptions[i];
                    break;
                }
                else
                {
                    currentWeatherDescription = "Current weather could not be established.";
                }
            }
        }
    }
}
