using MediatR;
using ProjectS.Core.Core.Command;
using ProjectS.Core.Events.Users;
using ProjectS.Core.Models;
using ProjectS.Core.Repositories;
using ProjectS.Core.Requests;
using ProjectS.Core.Shared.ValueObjects;

namespace ProjectS.Core.Handlers.Users;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, GenericCommandResult>
{
	#region Contructors

	public CreateUserHandler(
		IUserRepository userRepository,
		IMediator mediator
		)
	{
		_repository = userRepository;
		_mediator = mediator;
	}

	#endregion

	#region Propreties

	private readonly IUserRepository _repository;
	private readonly IMediator _mediator;

	#endregion

	#region Functions

	public async Task<GenericCommandResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
	{

		try
		{
			request.Validate();
			if (!request.IsValid)
				return new GenericCommandResult("New User Invalid", 400, notifications: request.Notifications);
		}
		catch
		{
			return new GenericCommandResult("Not possible to validate your request", 500);
		}

		try
		{
			bool exists = await _repository.AnyAsync(request.Email);

			if (exists)
				return new GenericCommandResult("This email is already in use", 400);
		}
		catch
		{
			return new GenericCommandResult("Fail to verify email", 500);
		}

		Account spendAccount;
		Account savingAccount;
		User newUser;

		try
		{
			spendAccount = new(
				new Name("Speding"),
				new Description("Account to spend money"),
				0);

			savingAccount = new(
				new Name("Savings"),
				new Description("Account to save money"),
				0);


			newUser = request.Convert();
			newUser.AddAccount([spendAccount, savingAccount]);

			await _repository.CreateAsync(newUser);
			await _mediator.Publish(new UserCreatedEvent(newUser.Id), cancellationToken);

			return new GenericCommandResult($"User {newUser.Id} successfully created", 200, newUser);
		}
		catch
		{
			return new GenericCommandResult("Fail to insert user in database", 500);
		}

	}

	#endregion

}
