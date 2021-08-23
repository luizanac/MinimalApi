using Minimal.Services;

namespace Minimal;

public static class Routes
{
	public static void AddRoutes(this WebApplication app)
	{
		app.MapGet("/api/users", (HttpContext context, UserService userService, string name) =>
			userService.CreateUser(name).WithResponse(context)
		);

		app.MapGet("/", () => "Hello World!");
	}
}
