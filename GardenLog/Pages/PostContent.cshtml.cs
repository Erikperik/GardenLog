using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace GardenLog.Pages
{
    [Authorize]
    public class PostContentModel : PageModel
    {     
        public void OnGet()
        {
        }
    }
}
