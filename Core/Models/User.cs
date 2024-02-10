using Flunt.Validations;
using ProjectS.Core.Core.Objects;
using ProjectS.Core.Models;
using ProjectS.Core.Shared.ValueObjects;

namespace ProjectS.Core.Models;

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

	public User(FullName name, Email email)
	{
		Name = name;
		Email = email;

		AddNotifications(Name, Email);
	}

	#endregion

	#region Propreties

	public FullName Name { get; init; }
	public Email Email { get; private set; }
	public Password Password { get; private set; }
	public ICollection<Account> Accounts { get; init; } = new List<Account>();

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

	public void AddAccount(Account account)
	{
		AddNotifications(account);
		Accounts.Add(account);
	}

	public void AddAccount(ICollection<Account> accounts)
	{
		foreach (Account account in accounts)
		{
			AddNotifications(account);
			Accounts.Add(account);
		}
	}

	#endregion
}
