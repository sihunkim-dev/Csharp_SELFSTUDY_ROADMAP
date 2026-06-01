using _02TaskTrackerwithJWT.Dtos;
using _02TaskTrackerwithJWT.Models;
using _02TaskTrackerwithJWT.Repositories;
using Microsoft.AspNetCore.Identity;

namespace _02TaskTrackerwithJWT.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    //Signup(USER)
    public async Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userDto)
    {
        var existingUser = await _userRepository.FindByEmailAsync(userDto.Email);
        if (existingUser != null)
        {
            return IdentityResult.Failed(new IdentityError
            {
                Code = "EmailAlreadyExists",
                Description = "Email already exists"
            });
        }

        //Dto -> Entity Mapping
        AppUser user = new AppUser
        {
            UserName = userDto.Email,
            Email = userDto.Email
        };

        var result = await _userRepository.CreateUserAsync(user, userDto.Password);

        if (result.Succeeded)
        {
            await _userRepository.AddToRoleAsync(user, "User");
        }

        return result;

    }
}