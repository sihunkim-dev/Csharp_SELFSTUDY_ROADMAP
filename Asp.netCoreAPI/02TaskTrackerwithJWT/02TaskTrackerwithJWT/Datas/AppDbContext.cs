using _02TaskTrackerwithJWT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace _02TaskTrackerwithJWT.Datas;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    
}