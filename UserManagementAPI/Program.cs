using UserManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<UserService>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Use custom middleware in correct order
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<LoggingMiddleware>();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();
