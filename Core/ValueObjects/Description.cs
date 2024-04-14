using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace ProjectS.Core.Shared.ValueObjects;

public class Description : ValueObject
{
    public Description(string value)
    {
        Value = value;

        AddNotifications(new DescriptionValidationContract(this));
    }

    public readonly string Value;
}

public class DescriptionValidationContract : Contract<Description>
{
    public DescriptionValidationContract(Description description)
    {
        Requires()
            .IsNotEmpty(description.Value, "Description", "Invalid description")
            .IsGreaterOrEqualsThan(description.Value, 3, "Description", "Description too short")
            .IsLowerOrEqualsThan(description.Value, 100, "Description", "Description too long");
    }
}