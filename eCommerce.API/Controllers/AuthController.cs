using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    // GET
    [HttpPost("register")] // POST api/auth/register
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);

        if (authenticationResponse == null || !authenticationResponse.Success)
        {
            return BadRequest(authenticationResponse);
        }
        
        return Ok(authenticationResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

        if (authenticationResponse == null || !authenticationResponse.Success)
        {
            return Unauthorized(authenticationResponse);
        }
        
        return Ok(authenticationResponse);
    }
}