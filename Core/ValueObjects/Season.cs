using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace ProjectS.Core.Shared.ValueObjects;

public class Season(DateTime startDate, DateTime endDate) : ValueObject
{
    public DateTime StartDate { get; init; } = startDate;
    public DateTime EndDate { get; init; } = endDate;
}

public class BasicCycleValidationContract : Contract<Season>
{
    public BasicCycleValidationContract(Season cycle)
    {
        Requires()
            .IsLowerThan(cycle.StartDate, cycle.EndDate, "StartDate", "StartDate can not be less then EndDate");
    }
}
