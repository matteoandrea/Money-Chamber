using Core.ValueObjects;
using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace ProjectS.Core.ValueObjects;

public class EnvelopeCycle : ValueObject
{
	public EnvelopeCycle(CycleType type, int quantity, DateTime date)
	{
		Type = type;
		Date = date;
		Quantity = quantity;
	}

	public EnvelopeCycle(DateTime date)
	{
		Type = CycleType.Monthly;
		Quantity = 1;
		Date = date;
	}

	public CycleType Type { get; init; }
	public int Quantity { get; init; }
	public DateTime Date { get; init; }
}

public enum CycleType
{
	Yearly,
	Monthly,
	Weekly
}

public class CycleValidationContract : Contract<EnvelopeCycle>
{
	public CycleValidationContract(EnvelopeCycle cycle)
	{
		Requires()
			.IsGreaterOrEqualsThan(1, cycle.Quantity, "Quantity", "Quantity can not less then one");
	}
}