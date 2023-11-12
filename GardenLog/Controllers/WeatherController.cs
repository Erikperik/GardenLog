using Microsoft.AspNetCore.Mvc;
using GardenLog.Models;
using GardenLog.Services;
using System.Linq.Expressions;

namespace GardenLog.Controllers
{
    public class WeatherController : Controller
    {
        public WeatherController(JsonFileWeatherService weatherService)
        {
            this.WeatherService = weatherService;
        }

        public JsonFileWeatherService WeatherService { get; }


        // makes a get requests for GetForecast
        [HttpGet]
        public Weatherforecast Get()
        {
            try
            {
                return WeatherService.GetForecast().Result;
            }
            catch
            {
                Response.Redirect("/error");
                throw;
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
