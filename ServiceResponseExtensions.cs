
using Luizanac.QueryExtensions.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Minimal;
public static class ServiceResponseExtensions
{
	public static IResult WithResponse<T>(this ServiceResponse<T> serviceResponse, HttpContext context) =>
		serviceResponse.Status switch
		{
			EServiceStatus.Ok => ProcessOk(context, serviceResponse),
			EServiceStatus.Error => Results.BadRequest(serviceResponse.Errors),
			EServiceStatus.NotFound => Results.NotFound(),
			EServiceStatus.Forbidden => Results.Forbid(),
			_ => Results.NotFound()
		};

	private static IResult ProcessOk<T>(HttpContext context, ServiceResponse<T> serviceResponse)
	{
		var isPaginated = serviceResponse.Data is not null &&
			serviceResponse.Data.GetType()
			.GetInterfaces()
			.Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IPagination<>));

		if (isPaginated)
		{
			//Paginated informations
			return Results.Ok(serviceResponse.Data);
		}

		return Results.Ok(serviceResponse.Data);
	}

}
