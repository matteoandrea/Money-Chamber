using Core.Events.Users;
using MassTransit;
using ProjectS.Core.Repositories;

namespace ProjectS.Core.Handlers.Envelopes;

public class CreateNewUserEnvelopersConsumerFail(IEnvelopeRepository _repository) : IConsumer<UserCreatedFail>
{
	#region Functions

	public async Task Consume(ConsumeContext<UserCreatedFail> context)
	{
		UserCreatedFail request = context.Message;
		await _repository.DeleteAllByUserIdAsync(request.UserId);
	}

	#endregion
}
