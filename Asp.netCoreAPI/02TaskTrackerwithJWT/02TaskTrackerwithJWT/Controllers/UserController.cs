using _02TaskTrackerwithJWT.Dtos;
using _02TaskTrackerwithJWT.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02TaskTrackerwithJWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegistUser([FromBody] UserRegistrationDto userDto)
    {
        var result = await _userService.RegisterUserAsync(userDto);

        if (result.Succeeded)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}