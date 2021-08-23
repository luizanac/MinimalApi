namespace Minimal.Services;

public class UserService
{
	public ServiceResponse<object> CreateUser(string name)
	{
		if (name is null)
			return new ServiceResponse<object>(new KeyValuePair<string, string>("Name", "Nome não pode ser nulo"));

		return new ServiceResponse<object>(new { Id = Guid.NewGuid(), Name = name });
	}

}
