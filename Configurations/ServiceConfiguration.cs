namespace Minimal.Configurations;

public static class ServiceConfiguration
{
	public static void AddServices(this IServiceCollection services)
	{
		services.AddScoped<IUserService, UserService>();
	}
}
