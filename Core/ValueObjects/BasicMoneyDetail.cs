using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace ProjectS.Core.ValueObjects;

public class BasicMoneyDetail : ValueObject
{
    public BasicMoneyDetail(decimal available, decimal allocated)
    {
        Available = available;
        Allocated = allocated;

        AddNotifications(new BasicDetailsValidationContract(this));
    }

    public decimal Available { get; init; }
    public decimal Allocated { get; init; }
}

public class BasicDetailsValidationContract : Contract<BasicMoneyDetail>
{
    public BasicDetailsValidationContract(BasicMoneyDetail details)
    {
        Requires()
            .IsGreaterOrEqualsThan(0, details.Allocated, "Allocated", "Allocated can not be negative")
            .IsGreaterOrEqualsThan(0, details.Available, "Available", "ToSpend can not be negative");
    }
}
