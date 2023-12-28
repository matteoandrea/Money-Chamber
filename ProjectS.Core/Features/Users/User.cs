using Standard.Core.Shared.Core.Objects;
using Standard.Core.Shared.ValueObjects;

namespace Standard.Core.Features.Users;

public class User : Entity
{
	public User(Name name, Email email)
	{
		Name = name;
		Email = email;

		AddNotifications(Name, Email);
	}

	public Name Name { get; private set; } 
	public Email Email { get; private set; }

	public ICollection<Task> Tasks { get; private set; } = new List<Task>();
}
