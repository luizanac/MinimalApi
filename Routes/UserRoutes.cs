using static Minimal.Dtos.UserDtos;

namespace Minimal.Routes;

public static class UserRoutes
{
	public static void AddUserRoutes(this WebApplication app)
	{
		app.MapPost("/api/users", (HttpContext context, IUserService userService, CreateUserDto dto) =>
			userService.Create(dto).WithResponse(context));

		app.MapGet("/api/users", (HttpContext context, IUserService userService) =>
			userService.GetAll().WithResponse(context));
	}
}
