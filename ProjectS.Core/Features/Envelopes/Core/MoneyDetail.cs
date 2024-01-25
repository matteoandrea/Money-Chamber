using Flunt.Validations;
using Standard.Core.Shared.Core.Objects;

namespace ProjectS.Core.Features.Envelopes.Core;

public class MoneyDetail : ValueObject
{
    public MoneyDetail(decimal toSpend, decimal spended)
    {
        ToSpend = toSpend;
        Spended = spended;

        AddNotifications(new BasicDetailsValidationContract(this));
    }

    public decimal ToSpend { get; init; }
    public decimal Spended { get; init; }
}

public class BasicDetailsValidationContract : Contract<MoneyDetail>
{
    public BasicDetailsValidationContract(MoneyDetail details)
    {
        Requires()
            .IsLowerOrEqualsThan(0, details.Spended, "Spended", "Spended can not be possitive")
            .IsGreaterOrEqualsThan(0, details.ToSpend, "ToSpend", "ToSpend can not be negative");
    }
}
