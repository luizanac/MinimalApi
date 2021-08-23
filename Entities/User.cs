namespace Minimal.Entities;

public class User : Entity
{
	public string Name { get; private set; }
	public uint Age { get; private set; }

	public User(string name, uint age)
	{
		Name = name;
		Age = age;
	}
}
