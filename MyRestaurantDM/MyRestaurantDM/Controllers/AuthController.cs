using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyRestaurantDM.Models.DTO;
using MyRestaurantDM.Repositories;

namespace MyRestaurantDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository repo;

        public AuthController(UserManager<IdentityUser> userManager , ITokenRepository repo)
        {
            this.userManager = userManager;
            this.repo = repo;
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

        //[HttpPost("Login")]

        //public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        //{
        //    var user = await userManager.FindByEmailAsync(login.UserName);
        //    if (user == null)
        //    {
        //        return BadRequest("You doesn't belong here Or you might have entered wrong password");

        //    }

        //    var checkpassword = await userManager.CheckPasswordAsync(user, login.Password);
        //    if (user != null)
        //    {

        //        if (!checkpassword)
        //        {
        //            return BadRequest("Check your password , Its not the one you entered while registering");
        //        }


        //        //if (checkpassword)
        //        //{
        //        //    //Will Create token here
        //        //    return Ok();
        //        //}
        //    }

        //    //Get Roles for this user
        //    var roles = await userManager.GetRolesAsync(user);

        //    //Create Token
        //    if (roles == null)
        //    {
        //        return BadRequest("Role not found for the user , Please check and then update");
        //    }

        //    var jwtToken = repo.CreateJWTToken(user,roles.ToList());

        //    var response = new LoginResponseDto
        //    {
        //        JwtToken = jwtToken,
        //    };

        //    // return Ok("Bearer "+response);
        //    // return Ok("Bearer "+jwtToken);
        //    return Ok(response);

        //}

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.UserName);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    // Get Roles for this user
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Create Token

                        var jwtToken = repo.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("Username or password incorrect");
        }
    }
}
