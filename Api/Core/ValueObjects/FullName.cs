using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace ProjectS.Core.Shared.ValueObjects;

public class FullName : ValueObject
{
	public FullName(string firstName, string lastName)
	{
		FirstName = firstName.ToLower();
		LastName = lastName.ToLower();

		AddNotifications(new FullNameValidationContract(this));
	}

	public string FirstName { get; init; }
	public string LastName { get; init; }

	public override string ToString()
	{
		string firstName = char.ToUpper(FirstName[0]) + FirstName[1..];
		string lastName = char.ToUpper(LastName[0]) + LastName[1..];
		return firstName + " " + lastName;
	}
}

public class FullNameValidationContract : Contract<FullName>
{
	public FullNameValidationContract(FullName fullName)
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
