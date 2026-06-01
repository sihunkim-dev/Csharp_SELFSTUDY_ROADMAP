using _02TaskTrackerwithJWT.Datas;
using _02TaskTrackerwithJWT.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .InjectDbContext(builder.Configuration)
    .AddAppConfig(builder.Configuration)
    .AddIdentityHandlerAndStores()
    .ConfigureIdentityOptions()
    .AddIdentityAuth(builder.Configuration);

builder.Services.AddScoped<ISeeder, RoleSeeder>();
builder.Services.AddScoped<ApplicationSeeder>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    
    var appSeeder = scope.ServiceProvider.GetRequiredService<ApplicationSeeder>();
    await appSeeder.SeedAllAsync(db, scope.ServiceProvider);
    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.Run();
