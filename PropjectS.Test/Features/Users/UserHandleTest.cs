using Standard.Core.Features.Users;
using Standard.Core.Shared.ValueObjects;

namespace Standard.Test.Features.Users;

[TestClass]
public class UserHandleTest
{
	public UserHandleTest()
	{
		_userRepository = new FakeUserRepository();
	}

	private readonly IUserRepository _userRepository;

	#region Valid Credentials

	private readonly Name _validName = new("Bruce", "Wayne");
	private readonly Email _validEmail = new("brucewayne@gmail.com");

	#endregion


	#region Invalid Credentials

	private readonly Name _invalidName = new("Bru", "");
	private readonly Email _invalidEmail = new("brucewayne.com");

	#endregion


	[TestMethod]
	[TestCategory("Command")]
	public void With_valid_command_Should_create_create_user_command()
	{
		CreateUserCommand command = new(_validName, _validEmail);
		command.Validate();

		Assert.AreEqual(command.IsValid, true);
	}

	[TestMethod]
	[TestCategory("Command")]
	public void With_invalid_command_Should_not_create_create_user_command()
	{
		CreateUserCommand command = new(_invalidName, _invalidEmail);
		command.Validate();

		Assert.AreEqual(command.IsValid, false);
	}

	[TestMethod]
	[TestCategory("Handle")]
	public void With_valid_command_Should_create_user()
	{
		CreateUserCommand command = new(_validName, _validEmail);
		UserHandler handler = new (_userRepository);

		handler.Handler(command);
		Assert.AreEqual(handler.IsValid, true);
	}
}
