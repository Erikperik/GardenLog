using GardenLog.Models;
using GardenLog.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GardenLog.Pages
{
    public class LogbookModel : PageModel
    {
        public GetBlogPostService? GetBlogPostService;
        public List<BlogPost>? postList { get; set; }

        public LogbookModel(
            GetBlogPostService? getBlogPostService)
        {
            GetBlogPostService = getBlogPostService;
        }

        public void OnGet()
        {
            postList = GetBlogPostService.GetBlogPosts();
        }
    }
}
