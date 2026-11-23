using Project_Step4.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.MapControllers();

app.Run();
