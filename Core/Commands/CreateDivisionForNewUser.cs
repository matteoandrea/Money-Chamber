using Core.Core;

namespace Core.Commands;

public class CreateDivisionForNewUser(string userId) : Command
{
	public string UserId { get; init; } = userId;

	public override void Validate()
	{
		throw new NotImplementedException();
	}
}

