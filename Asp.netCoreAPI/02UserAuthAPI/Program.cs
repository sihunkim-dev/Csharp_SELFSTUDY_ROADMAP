using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UserAuthAPI.Extensions;
using UserAuthAPI.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.InjectDbContext(builder.Configuration);

builder.Services.AddIdentity<User,Role>()
    .AddEntityFrameworkStores<UserDbContext>();


builder.Services.AddControllers();



builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();
