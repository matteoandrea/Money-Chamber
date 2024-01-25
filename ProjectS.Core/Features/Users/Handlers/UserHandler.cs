using Flunt.Notifications;
using ProjectS.Core.Features.Accounts.Core;
using ProjectS.Core.Features.Accounts.Handlers;
using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.Features.Envelopes.Handlers;
using ProjectS.Core.Features.Users.Commands;
using ProjectS.Core.Features.Users.Core;
using Standard.Core.Shared.Core.Command;
using Standard.Core.Shared.ValueObjects;

namespace ProjectS.Core.Features.Users.Handlers;

public class UserHandler : Notifiable<Notification>, IHandler<CreateUserCommand>
{
	#region Contructors

	public UserHandler(
		IUserRepository userRepository,
		IEnvelopeRepository envelopeRepository,
		IAccountRepository accountRepository
		)
	{
		_userRepository = userRepository;
		_envelopeRepository = envelopeRepository;
		_accountRepository = accountRepository;
	}

	#endregion

	#region Propreties

	private readonly IUserRepository _userRepository;
	private readonly IEnvelopeRepository _envelopeRepository;
	private readonly IAccountRepository _accountRepository;

	#endregion

	#region Functions

	public async Task<ICommandResult> Handler(CreateUserCommand command)
	{
		try
		{
			command.Validate();
			if (!command.IsValid)
				return new GenericCommandResult("New User Invalid", 400, notifications: command.Notifications);
		}
		catch
		{
			return new GenericCommandResult("Not possible to validate your request", 500);
		}

		try
		{
			bool exists = await _userRepository.AnyAsync(command.Email);
			if (exists)
				return new GenericCommandResult("This email is already in use", 400);
		}
		catch
		{
			return new GenericCommandResult("Fail to verify email", 500);
		}

		User newUser;

		try
		{
			newUser = command.Convert();
			await _userRepository.CreateAsync(newUser);

		}
		catch
		{
			return new GenericCommandResult("Fail to insert user in database", 500);
		}

		Account account;

		try
		{
			account = new(
				new Name("Main"),
				new Description("Account to spend"),
				0);

			await _accountRepository.CreateAsync(account);
		}
		catch
		{
			return new GenericCommandResult("Fail to insert account in database", 500);
		}

		try
		{
			Section emergencySection = new(
				new Name("Emergency"),
				new MoneyDetail(0, 0),
				new Cycle(0),
				[account]
				);

			Envelope tributeEnvelope = new(
				new Name("Tribute"),
				EnvelopeType.Tribute,
				new MoneyDetail(0, 0),
				[emergencySection],
				DateTime.UtcNow
				);

			Envelope foodEnvelope = new(
				new Name("Food"),
				EnvelopeType.Food,
				new MoneyDetail(0, 0),
				[emergencySection],
				DateTime.UtcNow
				);

			Envelope toolEnvelope = new(
				new Name("Tool"),
				EnvelopeType.Tool,
				new MoneyDetail(0, 0),
				[emergencySection],
				DateTime.UtcNow
				);

			await _envelopeRepository.CreateAsync([tributeEnvelope, foodEnvelope, toolEnvelope]);
		}
		catch
		{
			return new GenericCommandResult("Fail to insert envelopes in database", 500);
		}


		return new GenericCommandResult($"User {newUser.Id} successfully created", 200, newUser);
	}

	#endregion
}
