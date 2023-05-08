using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace DotNetIdentityAuthentication_Authorization.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty] 
        public Credentials Credential { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Credential.Username == "admin" && Credential.Password =="password")
            {
                //Creating the Security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"admin"),
                    new Claim (ClaimTypes.Email,"admin@gmail.com"),
                    new Claim ("Department","HR"),
                    new Claim ("Admin" , "true"),
                    new Claim ("Manager", "true")

                };

                var identity = new ClaimsIdentity(claims , "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

               await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }

    public class Credentials
    {
        [Key]
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set;}
        [Required]
        [Display(Name ="Password")]
        public string Password { get; set;}
    }
}
