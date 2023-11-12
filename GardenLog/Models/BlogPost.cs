using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GardenLog.Models
{
    public class BlogPost
    {
        [Required]
        public string? title { get; set; }
        public string? date { get; set; }
        [Required]
        public string? content { get; set; }
    }
}
