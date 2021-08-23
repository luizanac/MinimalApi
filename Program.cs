var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.AddRoutes();

app.Run();