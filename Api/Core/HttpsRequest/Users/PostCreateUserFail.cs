using Core.Core;

namespace Core.HttpsRequest.Users;

public class PostCreateUserFail(string userId) : Command
{
    public string UserId { get; init; } = userId;

	public override void Validate()
	{
		throw new NotImplementedException();
	}
}
