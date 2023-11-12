using GardenLog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GardenLog.Services
{
    
    public class CreateJsonBlogPostService
    {   
        // Summary:
        // Stores created blog posts as JSON-files in wwwroot/data/blogposts
        public CreateJsonBlogPostService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "blogposts");

        // create and store the JSON-file
        [HttpPost]
        public void CreateJsonFile(BlogPost blogPostForm)
        {
        var json = JsonSerializer.Serialize(blogPostForm);
        var path = JsonFileName + "/" + blogPostForm.title + ".JSON";
        File.WriteAllText(path, json);
        }
    }
}
