using GardenLog.Models;
using System.Text.Json;

namespace GardenLog.Services
{
    // Summary:
    // Gets all blogposts from wwwroot/data/blogposts

    public class GetBlogPostService
    {
        public GetBlogPostService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        
        private string BlogPosts => Path.Combine(WebHostEnvironment.WebRootPath, "data", "blogposts");

        public List<BlogPost> GetBlogPosts()
        {
            List<BlogPost> postsList = new List<BlogPost>();

            
            foreach (string fileName in Directory.GetFiles(BlogPosts, "*.json")){
                using var jsonFileReader = File.OpenText(fileName);
                BlogPost post = JsonSerializer.Deserialize<BlogPost>(jsonFileReader.ReadToEnd());
                postsList.Add(post);
            }



            return postsList ?? throw new ArgumentNullException();
        }
    }
}
