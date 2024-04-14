using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace ProjectS.Core.Shared.ValueObjects;

public class Season(DateTime startDate) : ValueObject
{
	public DateTime StartDate { get; init; } = startDate;
	public DateTime EndDate { get; init; } = startDate.AddMonths(1).AddDays(-1);
}

public class BasicCycleValidationContract : Contract<Season>
{
	public BasicCycleValidationContract(Season cycle)
	{
		Requires()
			.IsLowerThan(cycle.StartDate, cycle.EndDate, "StartDate", "StartDate can not be less then EndDate");
	}
}
