using Core.Commands;
using Core.Core;
using Core.Events.User;
using Core.Events.Users;
using Core.HttpsRequest.Users;
using MassTransit;
using ProjectS.Core.Models;
using ProjectS.Core.Repositories;
using ProjectS.Core.Shared.ValueObjects;

namespace Core.Consumers.Users;

public class CreateUserConsumer : IConsumer<CreateUser>
{

	#region Constructors

	public CreateUserConsumer() { }

	public CreateUserConsumer(
		IUserRepository repository,
		IPublishEndpoint publishEndpoint,
		IRequestClient<CreateNewUserEnvelopers> envelopeRequest)
	{
		_repository = repository;
		_publishEndpoint = publishEndpoint;
		_envelopeRequest = envelopeRequest;
	}

	#endregion

	#region Properties

	private readonly IUserRepository _repository;
	private readonly IPublishEndpoint _publishEndpoint;
	private readonly IRequestClient<CreateNewUserEnvelopers> _envelopeRequest;

	#endregion

	#region Functions

	public async Task Consume(ConsumeContext<CreateUser> context)
	{

		CreateUser request = context.Message;

		try
		{
			request.Validate();
			if (!request.IsValid)
			{
				await context.RespondAsync<GenericCommandResult>(new("New User Invalid", 400, request.Notifications));
				return;
			}

		}
		catch
		{
			await context.RespondAsync<GenericCommandResult>(new("Not possible to validate your request", 500));
			return;
		}

		try
		{
			bool exists = await _repository.AnyAsync(request.Email);

			if (exists)
			{
				await context.RespondAsync<GenericCommandResult>(new("This email is already in use", 400));
				return;
			}

		}
		catch
		{
			await context.RespondAsync<GenericCommandResult>(new("Fail to verify email", 500));
			return;
		}

		Account spendAccount;
		Account savingAccount;
		User newUser;


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

		Response<GenericCommandResult> envelopeResponse = await _envelopeRequest.GetResponse<GenericCommandResult>(new(newUser.Id));
		GenericCommandResult envelopeResult = envelopeResponse.Message;

		if (!envelopeResult.Success)
		{
			await context.RespondAsync<GenericCommandResult>(new(envelopeResult.Message, 400));
			return;
		}

		try
		{
			await _repository.CreateAsync(newUser);
			await _publishEndpoint.Publish(new UserCreated(newUser.Id));
			await context.RespondAsync<GenericCommandResult>(new($"User {newUser.Id} successfully created", 200, newUser));
		}
		catch
		{
			await _publishEndpoint.Publish(new UserCreatedFail(newUser.Id));
			await context.RespondAsync<GenericCommandResult>(new("Fail to insert user in database", 500));
		}
	}

	#endregion

}