using Luizanac.QueryExtensions.Abstractions.Interfaces;
using Minimal.Services.Enums;

namespace Minimal.Services.Extensions;

public static class ServiceResponseExtensions
{
	public static IResult WithResponse(this IServiceResponse serviceResponse, HttpContext context) =>
		serviceResponse.Status switch
		{
			EServiceStatus.Ok => ProcessOk(context, serviceResponse),
			EServiceStatus.Error => Results.BadRequest(serviceResponse.Errors),
			EServiceStatus.NotFound => Results.NotFound(),
			EServiceStatus.Forbidden => Results.Forbid(),
			_ => Results.NotFound()
		};

	private static IResult ProcessOk(HttpContext context, IServiceResponse serviceResponse)
	{
		var isPaginated = serviceResponse.Data?.GetType()
			.GetInterfaces()
			.Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IPagination<>));

		if (serviceResponse.Data is not null &&
			isPaginated.HasValue &&
			isPaginated.Value)
		{
			var type = serviceResponse.Data.GetType();
			context.Response.Headers.Add("X-Data-Count", GetTotalDataCount(type, serviceResponse));
			context.Response.Headers.Add("X-Page-Count", GetTotalPages(type, serviceResponse));
			context.Response.Headers.Add("X-Current-Page", GetCurrentPage(type, serviceResponse));

			var data = GetData(type, serviceResponse);

			return Results.Ok(data);
		}

		return Results.Ok(serviceResponse.Data);
	}

	private static object? GetData(Type type, IServiceResponse serviceResponse) =>
		type.GetProperty(nameof(IPagination<object>.Data))?.GetValue(serviceResponse.Data);

	private static string? GetTotalDataCount(Type type, IServiceResponse serviceResponse) =>
		type.GetProperty(nameof(IPagination<object>.TotalDataCount))?.GetValue(serviceResponse.Data)?.ToString();

	private static string? GetTotalPages(Type type, IServiceResponse serviceResponse) =>
		type.GetProperty(nameof(IPagination<object>.TotalPages))?.GetValue(serviceResponse.Data)?.ToString();


	private static string? GetCurrentPage(Type type, IServiceResponse serviceResponse) =>
		type.GetProperty(nameof(IPagination<object>.CurrentPage))?.GetValue(serviceResponse.Data)?.ToString();


}
