using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace Core.ValueObjects;

public class MoneyDetails(decimal allocate,
							decimal spend,
							decimal stash,
							decimal target) : ValueObject
{     
	public decimal Allocate { get; init; } = allocate;
	public decimal Spend { get; init; } = spend;
	public decimal Stash { get; init; } = stash;
	public decimal Target { get; init; } = target;
}


public class MoneyDetailsValidationContract : Contract<MoneyDetails>
{
	public MoneyDetailsValidationContract(MoneyDetails details)
	{
		Requires()
			.IsGreaterOrEqualsThan(0, details.Allocate, "Allocate", "Allocate can not be negative")
			.IsGreaterOrEqualsThan(0, details.Spend, "Spend", "Spend can not be negative")
			.IsGreaterOrEqualsThan(0, details.Stash, "Stash", "Stash can not be negative")
			.IsGreaterOrEqualsThan(0, details.Target, "Target", "Target can not be negative");
	}
}