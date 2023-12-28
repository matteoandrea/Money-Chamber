using Flunt.Validations;
using Standard.Core.Shared.Core.Objects;

namespace Standard.Core.Shared.ValueObjects;

public class Description : ValueObject
{
    public Description(string value)
    {
        Value = value;

        AddNotifications(new CreateDescriptionContract(this));
    }

    public string Value { get; private set; }
}

public class CreateDescriptionContract : Contract<Description>
{
    public CreateDescriptionContract(Description description)
    {
        Requires()
            .IsNotEmpty(description.Value, "Description", "Ivalid description")
            .IsGreaterOrEqualsThan(description.Value, 3, "Description", "Description too short")
            .IsLowerOrEqualsThan(description.Value, 50, "Description", "Description too long");
    }
}