var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSwagger();
builder.Services.ConfigureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.ConfigureSwagger();
app.AddRoutes();

app.Run();