using Flunt.Validations;
using Standard.Core.Shared.Core.Objects;

namespace Standard.Core.Shared.ValueObjects;

public class FullName : ValueObject
{
	public FullName(string firstName, string lastName)
	{
		FirstName = firstName.ToLower();
		LastName = lastName.ToLower();

		AddNotifications(new BasicFullNameValidationContract(this));
	}

	public string FirstName { get; init; }
	public string LastName { get; init; }
}

public class BasicFullNameValidationContract : Contract<FullName>
{
	public BasicFullNameValidationContract(FullName fullName)
	{
		Requires()
			.IsNotNullOrEmpty(fullName.FirstName, "FirstName", "Invalid name")
			.IsGreaterOrEqualsThan(fullName.FirstName, 4, "FirstName", "Must be a longer name")
			.IsLowerOrEqualsThan(fullName.FirstName, 10, "FirstName", "Must be a shorter name")

			.IsNotNullOrEmpty(fullName.LastName, "LastName", "Invalid name")
			.IsGreaterOrEqualsThan(fullName.LastName, 4, "LastName", "Must be a longer name")
			.IsLowerOrEqualsThan(fullName.LastName, 10, "LastName", "Must be a shorter name");
	}
}
