using System.Text;
using _02TaskTrackerwithJWT.Datas;
using _02TaskTrackerwithJWT.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace _02TaskTrackerwithJWT.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityHandlerAndStores(this IServiceCollection services)
    {
        services
            .AddIdentityApiEndpoints<AppUser>() //SPA(React, Vue 등)나 모바일 앱과 통신하는 REST API를 위한 Identity 설정을 자동으로 구성합니다.
            .AddRoles<IdentityRole>() //
            .AddEntityFrameworkStores<AppDbContext>();
        
        return services;
    }

    //Create the custom password policies
    public static IServiceCollection ConfigureIdentityOptions(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.User.RequireUniqueEmail = true;
        });
        return services;
    }
    
    //Authenticaiton
    public static IServiceCollection AddIdentityAuth(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //app의 기본 인증방식을 JWT방식으로 지정
            .AddJwtBearer(y =>
            {
                y.SaveToken = false; //stateless 
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        
        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
        });
        return services;
    }

    public static WebApplication AddIdentityAuthMiddlewares(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}