using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GardenLog.Models
{
    
    public class Weatherforecast
    {
        [Required]
        public decimal? latitude { get; set; }
        [Required]
        public decimal? longitude { get; set; }
        [Required]
        public decimal? generationtime_ms { get; set; }
        [Required]
        public int? utc_offset_seconds { get; set; }
        [Required]
        public string? timezone { get; set; }
        [Required]
        public string? timezone_abbreviation { get; set; }
        [Required]
        public decimal? elevation { get; set; }
        [Required]
        public CurrentWeatherUnits? current_weather_units { get; set; }
        [Required]
        public CurrentWeather? current_weather { get; set; }
        [Required]
        public DailyUnits? daily_units { get; set; }
        [Required]
        [JsonPropertyName ("daily")]
        public DailyData? daily_data { get; set; }
    }

    public class CurrentWeatherUnits
    {
        [Required]
        public string? time { get; set; }
        [Required]
        public string? temperature { get; set; }
        [Required]
        public string? windspeed { get; set; }
        [Required]
        public string? winddirection { get; set; }
        [Required]
        public string? is_day { get; set; }
        [Required]
        public string? weathercode { get; set; }
    }

    public class CurrentWeather
    {
        [Required]
        public string? time { get; set; }
        [Required]
        public decimal? temperature { get; set; }
        [Required]
        public decimal? windspeed { get; set; }
        [Required]
        public decimal? winddirection { get; set; }
        [Required]
        public decimal? is_day { get; set; }
        [Required]
        public decimal? weathercode { get; set; }
    }

    public class DailyUnits
    {
        [Required]
        public string? time { get; set; }
        [Required]
        public string? weathercode { get; set; }
        [Required]
        public string? temperature_2m_max { get; set; }
        [Required]
        public string? temperature_2m_min { get; set; }
        [Required]
        public string? precipitation_sum { get; set; }
        [Required]
        public string? windspeed_10m_max { get; set; }
        [Required]
        public string? windgusts_10m_max { get; set; }
        [Required]
        public string? winddirection_10m_dominant { get; set; }
    }
    public class DailyData
    {
        [Required]
        public string[]? time { get; set; }
        [Required]
        public decimal[]? weathercode { get; set; }
        [Required]
        public decimal[]? temperature_2m_max { get; set; }
        [Required]
        public decimal[]? temperature_2m_min { get; set; }
        [Required]
        public decimal[]? precipitation_sum { get; set; }
        [Required]
        public decimal[]? windspeed_10m_max { get; set; }
        [Required]
        public decimal[]? windgusts_10m_max { get; set; }
        [Required]
        public decimal[]? winddirection_10m_dominant { get; set; }
    }
}