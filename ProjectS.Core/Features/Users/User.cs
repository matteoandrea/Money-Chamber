using Flunt.Validations;
using ProjectS.Core.Shared.ValueObjects;
using Standard.Core.Shared.Core.Objects;
using Standard.Core.Shared.ValueObjects;

namespace Standard.Core.Features.Users;

public class User : Entity
{
	#region Constructors

	protected User()
	{

	}

	public User(Name name, Email email, string? password = null)
	{
		Name = name;
		Email = email;
		Password = new(password);

		AddNotifications(Name, Email);
	}

	#endregion

	#region Propreties

	public Name Name { get; private set; }
	public Email Email { get; private set; }
	public Password Password { get; private set; }
	//public ICollection<Task> Tasks { get; private set; } = new List<Task>();

	#endregion

	#region Functions

	public void UpdatePassword(string plainTextPassword, string code)
	{
		if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
			throw new Exception("Código de restauração inválido");

		var password = new Password(plainTextPassword);
		Password = password;
	}

	public void UpdateEmail(Email email)
	{
		Email = email;
	}

	public void ChangePassword(string plainTextPassword)
	{
		var password = new Password(plainTextPassword);
		Password = password;
	}

	#endregion
}
