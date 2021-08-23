using Microsoft.OpenApi.Models;

namespace Minimal.Configurations;

public static class SwaggerConfiguration
{
	public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo()
		{
			Description = "Web api implementation using Minimal Api in Asp.Net Core",
			Title = "MinimalApi",
			Version = "v1",
			Contact = new OpenApiContact()
			{
				Name = "MinimalApi",
			}
		}));

		return services;
	}

	public static void ConfigureSwagger(this WebApplication app)
	{
		app.UseSwagger();

		app.UseSwaggerUI(c =>
		{
			c.RoutePrefix = string.Empty;
		});
	}
}
