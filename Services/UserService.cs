using Luizanac.QueryExtensions.Abstractions.Models;
using Minimal.Entities;
using static Minimal.Dtos.UserDtos;

namespace Minimal.Services;

public class UserService : IUserService
{
	public IServiceResponse Create(CreateUserDto dto)
	{
		if (dto.Age < 18)
			return new ServiceResponse(new KeyValuePair<string, string>("age", "youer age must be great than 18"));

		var user = new User(dto.Name, dto.Age);

		return new ServiceResponse(new UserDto(user.Id, user.Name, user.Age));
	}

	public IServiceResponse GetAll()
	{
		var users = new List<User>
		{
			new User("User 1", 19),
			new User("User 2", 20),
			new User("User 3", 25)
		};

		var mappedUsers = users.Select(x => new UserDto(x.Id, x.Name, x.Age));

		return new ServiceResponse(new Pagination<IEnumerable<UserDto>>(mappedUsers, 10, 1, mappedUsers.Count(), 0, 2, 10));
	}
}

public interface IUserService
{
	IServiceResponse Create(CreateUserDto dto);
	IServiceResponse GetAll();
}