using Minimal.Services.Enums;

namespace Minimal.Services.Extensions;

public class ServiceResponse : IServiceResponse
{
	public string Message { get; set; } = "We have an error :o";
	public EServiceStatus Status { get; set; }
	public object? Data { get; set; }
	public Dictionary<string, List<string>>? Errors { get; set; }

	public ServiceResponse(EServiceStatus status)
	{
		Status = status;
	}

	public ServiceResponse(object data)
	{
		Status = EServiceStatus.Ok;
		Data = data;
	}

	public ServiceResponse(KeyValuePair<string, string> error)
	{
		Status = EServiceStatus.Error;
		Errors = new Dictionary<string, List<string>>
		{
			{ error.Key, new List<string>() { error.Value } }
		};
	}

	public ServiceResponse(IEnumerable<KeyValuePair<string, string>> errors)
	{
		Status = EServiceStatus.Error;
		Errors = new Dictionary<string, List<string>>();

		foreach (var error in errors)
		{
			if (Errors.ContainsKey(error.Key))
				Errors[error.Key].Add(error.Value);
			else
			{
				Errors.Add(error.Key, new List<string> { error.Value });
			}
		}
	}
}

public interface IServiceResponse
{
	public string Message { get; set; }
	public EServiceStatus Status { get; set; }
	public object? Data { get; set; }
	public Dictionary<string, List<string>>? Errors { get; set; }
}