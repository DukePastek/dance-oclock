using DanceOClock.Api.Services;
using DanceOClock.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DanceOClock.Api.Features.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(UserManager<ApplicationUser> userManager, TokenService tokenService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null || !await userManager.CheckPasswordAsync(user, request.Password))
        {
            return Unauthorized();
        }

        var token = tokenService.CreateToken(user);
        return Ok(new LoginResponse
        {
            Token = token,
            Email = user.Email ?? string.Empty,
            DisplayName = user.DisplayName
        });
    }
}
