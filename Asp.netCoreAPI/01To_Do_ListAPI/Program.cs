using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!) 
);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
