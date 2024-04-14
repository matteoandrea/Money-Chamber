using Core.HttpsRequest.Users;
using MassTransit;
using ProjectS.Core.Repositories;

namespace ProjectS.Core.Consumers.Divisions;

public class CreateDivisionForNewUserConsumerFail(IDivisionRepository _repository) : IConsumer<PostCreateUserFail>
{
	#region Functions

	public async Task Consume(ConsumeContext<PostCreateUserFail> context)
	{
		PostCreateUserFail request = context.Message;
		await _repository.DeleteAllByUserIdAsync(request.UserId);
	}

	#endregion
}
