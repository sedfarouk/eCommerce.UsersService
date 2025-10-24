using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    // GET /api/Users/{userId}
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserByUserID(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return BadRequest("Invalid user id");
        }

        UserDTO? response = await _usersService.GetUserByUserID(userId);

        if (response == null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }
}