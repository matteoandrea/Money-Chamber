using Flunt.Validations;
using Standard.Core.Shared.Core.Objects;
using Standard.Core.Shared.ValueObjects;

namespace ProjectS.Core.Features.Accounts.Core;

public class Account : Entity
{
    public Account(Name name, Description description, decimal totalAmount)
    {
        Name = name;
        TotalAmount = totalAmount;
        Description = description;

        AddNotifications(name, description,this);
    }

    public Name Name { get; init; }
    public Description Description { get; init; }

    public decimal TotalAmount { get; init; }
}

public class BasicAccountValidationContract : Contract<Account>
{
	public BasicAccountValidationContract(Account account)
	{
		Requires()			
			.IsGreaterOrEqualsThan(0, account.TotalAmount, "TotalAmount", "Total amount can not be negative");
	}
}

