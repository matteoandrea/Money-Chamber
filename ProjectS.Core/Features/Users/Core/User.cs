using Flunt.Validations;
using ProjectS.Core.Features.Accounts.Core;
using ProjectS.Core.Shared.ValueObjects;
using Standard.Core.Shared.Core.Objects;
using Standard.Core.Shared.ValueObjects;

namespace ProjectS.Core.Features.Users.Core;

public class User : Entity
{
	#region Constructors


	public User(FullName name, Email email, ICollection<Account> accounts, string? password = null)
	{
		Name = name;
		Email = email;
		Accounts = accounts;
		Password = new(password);

		AddNotifications(Name, Email);
	}

	public User(FullName name, Email email, Account account, string? password = null)
	{
		Name = name;
		Email = email;

		Password = new(password);

		Accounts = new List<Account>
		{
			account
		};

		AddNotifications(Name, Email);
	}

	#endregion

	#region Propreties

	public FullName Name { get; init; }
	public Email Email { get; private set; }
	public Password Password { get; private set; }
	public ICollection<Account> Accounts { get; init; }

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
