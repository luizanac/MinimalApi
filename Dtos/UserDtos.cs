namespace Minimal.Dtos;

public class UserDtos
{
	public record CreateUserDto([Required] string Name, uint Age);
	public record UserDto(Guid Id, string Name, uint Age);
}
