using Flunt.Validations;
using ProjectS.Core.Core.Objects;
using ProjectS.Core.Shared.ValueObjects;

namespace ProjectS.Core.Models;

public class Account : Entity
{
	public Account(Name name, Description description, decimal totalAmount)
	{
		Name = name;
		TotalAmount = totalAmount;
		Description = description;

		AddNotifications(name, description, this);
	}

	public readonly Name Name;
	public readonly Description Description;
	public readonly decimal TotalAmount;
}

public class BasicAccountValidationContract : Contract<Account>
{
	public BasicAccountValidationContract(Account account)
	{
		Requires()
			.IsGreaterOrEqualsThan(0, account.TotalAmount, "TotalAmount", "Total amount can not be negative");
	}
}

