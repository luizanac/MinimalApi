namespace Minimal.Routes;

public static class RouteAggregator
{
	public static void AddRoutes(this WebApplication app)
	{
		app.AddUserRoutes();
	}
}
