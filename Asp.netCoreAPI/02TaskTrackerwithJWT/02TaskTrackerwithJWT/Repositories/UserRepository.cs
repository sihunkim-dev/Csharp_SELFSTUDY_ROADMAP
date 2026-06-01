using _02TaskTrackerwithJWT.Datas;
using _02TaskTrackerwithJWT.Models;
using Microsoft.AspNetCore.Identity;

namespace _02TaskTrackerwithJWT.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    
    public UserRepository(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<AppUser?> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<IdentityResult> AddToRoleAsync(AppUser user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }
}