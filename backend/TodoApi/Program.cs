using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Repositories;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);




//load the environment variables
var configurations = builder.Configuration;
var connectionString = configurations.GetConnectionString("DefaultConnection")
    .Replace("${DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost")
    .Replace("${DB_PORT}", Environment.GetEnvironmentVariable("DB_PORT") ?? "5433")
    .Replace("${DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME") ?? "todoapp")
    .Replace("${DB_USER}", Environment.GetEnvironmentVariable("DB_USER") ?? "postgres")
    .Replace("${DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "0712@Danchiwaz."); 
    
    builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddScoped<ITaskRepository, TaskRepository>();
    builder.Services.AddScoped<TaskService>();
    builder.Services.AddControllers();
    // builder.Services.AddAuthorization();
    
    var app = builder.Build();
    app.UseRouting();
    //app.UseAuthorization();
    app.MapControllers();
    app.Run();