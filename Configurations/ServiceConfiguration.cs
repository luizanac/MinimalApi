namespace Minimal.Configurations;

public static class ServiceConfiguration
{
	public static void ConfigureServices(this IServiceCollection services)
	{
		services.AddScoped<IUserService, UserService>();
	}
}
