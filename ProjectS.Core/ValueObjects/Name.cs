using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace ProjectS.Core.Shared.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName)
    {
        FirstName = firstName.ToLower();

        AddNotifications(new BasicNameValidationContract(this));
    }

    public string FirstName { get; init; }
}

public class BasicNameValidationContract : Contract<Name>
{
    public BasicNameValidationContract(Name name)
    {
        Requires()
            .IsNotNullOrEmpty(name.FirstName, "FirstName", "Invalid name")
            .IsGreaterOrEqualsThan(name.FirstName, 4, "FirstName", "Must be a longer name")
            .IsLowerOrEqualsThan(name.FirstName, 50, "FirstName", "Must be a shorter name");
    }
}
