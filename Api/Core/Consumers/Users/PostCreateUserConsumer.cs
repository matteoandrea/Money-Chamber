using Core.Auth;
using Core.Commands;
using Core.Core;
using Core.HttpsRequest.Users;
using Core.ValueObjects;
using MassTransit;
using Microsoft.Extensions.Options;
using ProjectS.Core.Models;
using ProjectS.Core.Repositories;
using ProjectS.Core.Shared.ValueObjects;
using System.Collections.Immutable;

namespace Core.Consumers.Users;

public class PostCreateUserConsumer(
	IOptions<AuthSettings> options,
	IUserRepository repository,
	IPublishEndpoint publishEndpoint,
	IRequestClient<CreateDivisionForNewUser> divisionRequest) : IConsumer<PostCreateUser>
{
	#region Properties

	private readonly IOptions<AuthSettings> _options = options;
	private readonly IUserRepository _repository = repository;
	private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
	private readonly IRequestClient<CreateDivisionForNewUser> _divisionRequest = divisionRequest;

	#endregion

	#region Functions

	public async Task Consume(ConsumeContext<PostCreateUser> context)
	{

		PostCreateUser request = context.Message;
		if (!await Validate(request, context))
			return;

		ICollection<Account> accoutnts = GenerateAccounts();
		Password password = new(request.Password.Password);
		AuthToken authToken = new(request.Email.Address, _options);
		User user = new(request.Name, request.Email, password, accoutnts, authToken);

		Response<GenericCommandResult> divisionResponse = await _divisionRequest.GetResponse<GenericCommandResult>(new(user.Id));

		if (!divisionResponse.Message.Success)
		{
			await context.RespondAsync<GenericCommandResult>(new(divisionResponse.Message.Message, 400));
			return;
		}

		try
		{
			await _repository.CreateAsync(user);
			await context.RespondAsync<GenericCommandResult>(new($"User {user.Id} successfully created", 200, user));
		}
		catch
		{
			await _publishEndpoint.Publish(new PostCreateUserFail(user.Id));
			await context.RespondAsync<GenericCommandResult>(new("Fail to insert user in database", 500));
		}
	}

	private async Task<bool> Validate(PostCreateUser request, ConsumeContext context)
	{
		request.Validate();
		if (!request.IsValid)
		{
			await context.RespondAsync<GenericCommandResult>(new("New User Invalid", 400, null, request.Notifications));
			return false;
		}

		try
		{
			bool exists = await _repository.AnyAsync(request.Email);

			if (exists)
			{
				await context.RespondAsync<GenericCommandResult>(new("This email is already in use", 400));
				return false;
			}

		}
		catch
		{
			await context.RespondAsync<GenericCommandResult>(new("Fail to verify email", 500));
			return false;
		}

		return true;
	}

	private ICollection<Account> GenerateAccounts()
	{
		Account spendAccount = new(
			new Name("Speding"),
			new Description("Account to spend money"),
			0);

		Account savingAccount = new(
			new Name("Savings"),
			new Description("Account to save money"),
			0);

		return [spendAccount, savingAccount];
	}
	#endregion

}