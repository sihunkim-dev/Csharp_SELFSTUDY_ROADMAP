using Microsoft.AspNetCore.Identity;

namespace _03UserCommunity.Data.Entities;

public class User : IdentityUser<int>
{
    public string FullName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } 
}