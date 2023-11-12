using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using GardenLog.Services;
using GardenLog.Models;

namespace GardenLog.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential? Credential { get; set; }
        public GetUsersService? UsersService;
        public List<User>? Users { get; set; }
        public UserContext? UserContext { get; set; }

        public LoginModel(
            GetUsersService usersService,
            UserContext userContext)
        {
            UsersService = usersService;
            UserContext = userContext;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // get users from db using service
            if (UsersService != null && UserContext != null)
            {
                Users = UsersService.GetUsers(UserContext);
            }
            else
            {
                throw new ArgumentNullException();
            }

            if (Users != null && Credential != null && Credential.UserName != null && Credential.Password != null)
            {
                foreach (User user in Users)
                {
                    // verify the credential
                    if (Credential.UserName == user.Name && Credential.Password == user.Password)
                    {
                        // creating the security context, principal>identity>claim
                        var claims = new List<Claim> {
                            new Claim(ClaimTypes.Name, "admin")
                        };
                        var identity = new ClaimsIdentity(claims, "CookieAuth");
                        ClaimsPrincipal claimsPrincipal = new(identity);

                        await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

                        return RedirectToPage("/PostContent");

                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return Page();
        }
    }
    public class Credential
    {
        [Required]
        [Display(Name = "Username")]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
