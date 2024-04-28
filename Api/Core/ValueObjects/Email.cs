using Flunt.Validations;
using ProjectS.Core.Core.Objects;

namespace ProjectS.Core.Shared.ValueObjects;

public class Email : ValueObject
{
	#region Constructors
	public Email() { }

	public Email(string adress)
	{
		Address = adress.Trim().ToLower();
		//VerificationCode = new();
		AddNotifications(new EmailValidationContract(this));
	}

	#endregion

	#region Propreties

	public string Address { get; init; }
	//public VerificationCode VerificationCode { get; private set; }

	#endregion

	#region Functions

	public override string ToString() => Address;

	//public void ResendVerification()
	//{
	//    VerificationCode = new();
	//}

	#endregion
}

public class EmailValidationContract : Contract<Email>
{
	public EmailValidationContract(Email email)
	{
		Requires()
			.IsEmail(email.Address, "Email", "Ivalid email");

	}
}