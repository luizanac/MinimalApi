using Microsoft.AspNetCore.Mvc;

namespace Minimal.Configurations;

public static class ConfigurationAggregator
{
	public static IServiceCollection ConfigureServices(this IServiceCollection services)
	{
		services.AddServices();

		return services;
	}
}
