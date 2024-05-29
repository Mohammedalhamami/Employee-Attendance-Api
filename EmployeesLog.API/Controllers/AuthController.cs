using EmployeesLog.API.Models.DTOs;
using EmployeesLog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EmployeesLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,

            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            
            if(identityResult.Succeeded)
            {
                //add roles to the user.
               identityResult = await userManager.AddToRoleAsync(identityUser, registerRequestDto.Role);
            
                if(identityResult.Succeeded )
                {
                    return Ok("User was registered successfully");
                }
            }
            return BadRequest("Something went wrong!");
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
           var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if(user != null)
            {
               var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if(roles is not null)
                    {
                        //generate token.
                      var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                      var response = new LogInResponseDto { jwtToken = jwtToken };
                        
                      return Ok(response);
                    }
                }
            }
            return BadRequest("Something went wrong!");
        }

    }
}
