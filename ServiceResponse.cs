namespace Minimal;

public class ServiceResponse<T>
{
	public string Message { get; set; } = "We have an error :o";
	public EServiceStatus Status { get; set; }
	public T? Data { get; set; }
	public Dictionary<string, List<string>>? Errors { get; set; }

	public ServiceResponse(EServiceStatus status)
	{
		Status = status;
	}

	public ServiceResponse(T data)
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
