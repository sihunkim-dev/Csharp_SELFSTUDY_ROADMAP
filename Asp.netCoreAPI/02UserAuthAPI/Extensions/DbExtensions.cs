using Microsoft.EntityFrameworkCore;
using UserAuthAPI.Models;

namespace UserAuthAPI.Extensions
{
    public static class DbExtensions
    {
        public static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration config)
        {   
            //Receive the connection into the variable
            var connectionString = config.GetConnectionString("Default");

            services.AddDbContext<UserDbContext>(options =>
                options.UseMySql(
                    connectionString, 
                    ServerVersion.AutoDetect(connectionString)
                ));
            
            return services;
        }
    }
}
