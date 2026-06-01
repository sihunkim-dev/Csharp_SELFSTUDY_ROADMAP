using _02TaskTrackerwithJWT.Models;
using Microsoft.AspNetCore.Identity;

namespace _02TaskTrackerwithJWT.Repositories;

public interface IUserRepository
{
    Task<IdentityResult> CreateUserAsync(AppUser user,  string password);
    Task<AppUser?> FindByEmailAsync(string email);
    
    Task<IdentityResult> AddToRoleAsync(AppUser user, string role); 
    
    //SignIn
    Task<bool> CheckPasswordAsync(AppUser user, string password);
    Task<IList<string>> GetUserRolesAsync(AppUser user);
    
}