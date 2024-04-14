using Core.ValueObjects;
using ProjectS.Core.Core.Objects;
using ProjectS.Core.Shared.ValueObjects;
using System.Collections.Immutable;

namespace ProjectS.Core.Models;

public class User : Entity
{
	#region Constructors

	protected User(
		string id,
				FullName name,
				Email email,
				Password password,
				ICollection<Account> accounts,
				AuthToken authToken) : base(id)
	{
		Name = name;
		Email = email;
		Accounts = accounts;
		Password = password;
		AuthToken = authToken;

		AddNotifications(Name, Email);
	}

	public User(FullName name,
			 Email email,
			 Password password,
			 ICollection<Account> accounts,
			 AuthToken authToken)
	{
		Name = name;
		Email = email;
		Accounts = accounts;
		Password = password;
		AuthToken = authToken;

		AddNotifications(Name, Email);
	}



	public User CopyWith(string? id = null,
					  FullName? name = null,
					  Email? email = null,
					  Password? password = null,
					  ICollection<Account>? accounts = null,
					  AuthToken? authToken = null)
	{
		return new User(id: id ?? Id,
				  name: name ?? Name,
				  email: email ?? Email,
				  password: password ?? Password,
				  accounts: accounts ?? Accounts,
				  authToken: authToken ?? AuthToken);
	}

	#endregion

	#region Propreties

	public FullName Name { get; init; }
	public Email Email { get; init; }
	public Password Password { get; init; }
	public ICollection<Account> Accounts { get; init; }
	public AuthToken AuthToken { get; init; }

	#endregion

	#region Functions

	//public void UpdatePassword(string plainTextPassword, string code)
	//{
	//	if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
	//		throw new Exception("Código de restauração inválido");

	//	var password = new Password(plainTextPassword);
	//	Password = password;
	//}

	//public void UpdateEmail(Email email)
	//{
	//	Email = email;
	//}

	//public void ChangePassword(string plainTextPassword)
	//{
	//	var password = new Password(plainTextPassword);
	//	Password = password;
	//}

	public User AddAccount(Account account)
	{
		ICollection<Account> newAccounts = [.. Accounts, .. new List<Account> { account }];
		return CopyWith(accounts: newAccounts);
	}

	public User AddAccount(ICollection<Account> accounts)
	{
		ICollection<Account> newAccounts = [.. Accounts, .. accounts];
		return CopyWith(accounts: newAccounts);
	}

	#endregion
}
