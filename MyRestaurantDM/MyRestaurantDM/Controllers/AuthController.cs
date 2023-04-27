using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyRestaurantDM.Models.DTO;

namespace MyRestaurantDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpPost("Register")]


        public async Task<IActionResult> Register([FromBody] RegisterRequestDto regi)
        {
            var IdentityUser = new IdentityUser
            {
                UserName = regi.UserName,
                Email = regi.UserName
            };

            var identityResult = await userManager.CreateAsync(IdentityUser, regi.Password);

            if (identityResult.Succeeded)
            {
                //To add Roles
                if (regi.Roles != null && regi.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(IdentityUser, regi.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please Login.");
                    }
                }

            }

            return BadRequest("Something went wrong");
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        {
            var user = await userManager.FindByEmailAsync(login.UserName);
            if (user == null)
            {
                return BadRequest("You doesn't belong here Or you might have entered wrong password");

            }

            var checkpassword = await userManager.CheckPasswordAsync(user, login.Password);
            if (user != null)
            {

                if (!checkpassword)
                {
                    return BadRequest("Check your password , Its not the one you entered while registering");
                }


                //if (checkpassword)
                //{
                //    //Will Create token here
                //    return Ok();
                //}
            }

            return Ok("Login Successful, Atluntadhi Manathoni");

        }


    }
}
