using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetIdentityAuthentication_Authorization.Pages
{
    [Authorize(Policy ="AdminOnly")]
    public class SettingsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
