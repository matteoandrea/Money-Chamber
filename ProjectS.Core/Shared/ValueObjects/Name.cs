using Flunt.Validations;
using Standard.Core.Shared.Core.Objects;

namespace Standard.Core.Shared.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName.ToLower();
        LastName = lastName.ToLower();

        AddNotifications(new CreateNameContract(this));
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}

public class CreateNameContract : Contract<Name>
{
    public CreateNameContract(Name name)
    {
        Requires()
            .IsNotNullOrEmpty(name.FirstName, "FirstName", "Invalid name")
            .IsGreaterOrEqualsThan(name.FirstName, 4, "FirstName", "Must be a longer name")
            .IsLowerOrEqualsThan(name.FirstName, 10, "FirstName", "Must be a shorter name")

            .IsNotNullOrEmpty(name.LastName, "LastName", "Invalid name")
            .IsGreaterOrEqualsThan(name.LastName, 4, "LastName", "Must be a longer name")
            .IsLowerOrEqualsThan(name.LastName, 10, "LastName", "Must be a shorter name");
    }
}
