using Core.Auth;
using Core.Core;
using Core.HttpsRequest.Auth;
using Core.ValueObjects;
using MassTransit;
using Microsoft.Extensions.Options;
using ProjectS.Core.Models;
using ProjectS.Core.Repositories;

namespace Core.Consumers.Auth;

public class PostLoginAuthConsumer(IOptions<AuthSettings> options,
								   IUserRepository userRepository) : IConsumer<PostLoginAuth>
{
	private readonly IOptions<AuthSettings> _options = options;
	private readonly IUserRepository _userRepository = userRepository;

	public async Task Consume(ConsumeContext<PostLoginAuth> context)
	{
		PostLoginAuth login = context.Message;

		login.Validate();
		if (!login.IsValid) await context.RespondAsync<GenericCommandResult>(new("Fail to login", 500, login.Notifications));

		try
		{
			User user = await _userRepository.GetByEmailAsync(login.EmailAdress.Address);
			
			bool validPassword = user.Password.Verify(login.Password.Password);

			if (!validPassword) {
				await context.RespondAsync<GenericCommandResult>(new("LoginError", 200, "Invalid Password"));
			}

			AuthToken authToken = new(user.Email.Address, _options);
			await _userRepository.UpdateTokenAsync(user.Id, authToken);
			await context.RespondAsync<GenericCommandResult>(new("Login", 200, authToken));
		}
		catch
		{
			await context.RespondAsync<GenericCommandResult>(new("Fail to login", 500));
		}
	}
}
