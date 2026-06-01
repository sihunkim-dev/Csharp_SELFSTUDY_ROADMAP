using System.Security.Claims;
using _02TaskTrackerwithJWT.Datas;
using _02TaskTrackerwithJWT.Dtos;
using _02TaskTrackerwithJWT.Repositories;
using Microsoft.Extensions.Options;

namespace _02TaskTrackerwithJWT.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly AppSettings _appSettings;

    public AuthService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
    {
        _userRepository = userRepository;
        _appSettings = appSettings.Value;
    }

    public async Task<string?> LoginAsync(UserSignInDto signInDto)
    {
        //User detail checking and validation of password
        var user = await _userRepository.FindByEmailAsync(signInDto.Email);
        if (user == null || !await _userRepository.CheckPasswordAsync(user, signInDto.Password))
        {
            return null;
        }
        
        var userRole = await _userRepository.GetUserRolesAsync(user);

        var claims = new List<Claim>
        {
            
        };

    }
}