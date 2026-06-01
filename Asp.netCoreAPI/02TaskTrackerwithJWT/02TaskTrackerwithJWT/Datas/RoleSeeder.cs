using Microsoft.AspNetCore.Identity;

namespace _02TaskTrackerwithJWT.Datas;

public class RoleSeeder : ISeeder
{
    public async Task SeedAsync(AppDbContext context, IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

        string[] roleName = { "Admin", "User" };

        foreach (var role in roleName)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(role));
            }
        }
    }

}