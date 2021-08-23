
using Minimal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.AddRoutes();

app.Run();