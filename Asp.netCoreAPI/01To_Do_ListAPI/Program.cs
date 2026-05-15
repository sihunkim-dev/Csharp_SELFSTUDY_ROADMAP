using Microsoft.EntityFrameworkCore;
using To_Do_ListAPI.Repositories;
using To_Do_ListAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!) 
);

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<TodoService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();
    
app.MapGet("/", () => "Hello World!");

app.Run();
