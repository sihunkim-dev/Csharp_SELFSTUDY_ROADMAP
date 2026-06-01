using _02TaskTrackerwithJWT.Datas;
using Microsoft.EntityFrameworkCore;

namespace _02TaskTrackerwithJWT.Extensions;

public static class DbExtensions
{
    public static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration  config)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultDB"));
        });
        return services;
    }
}