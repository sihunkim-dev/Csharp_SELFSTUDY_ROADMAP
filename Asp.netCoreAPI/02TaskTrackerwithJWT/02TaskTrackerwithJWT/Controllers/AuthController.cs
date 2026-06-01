using _02TaskTrackerwithJWT.Datas;
using _02TaskTrackerwithJWT.Dtos;
using _02TaskTrackerwithJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _02TaskTrackerwithJWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> SignIn([FromBody] UserSignInDto userSignIn)
    {
        //Model Validation
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var token = await _auth
    }
}