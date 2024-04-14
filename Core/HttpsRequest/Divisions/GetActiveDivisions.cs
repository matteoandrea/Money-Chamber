using Core.Core;

namespace Core.HttpsRequest.Divisions;

public class GetActiveDivisions(string userId) : Command
{
	public string UserId { get; init; } = userId;

	public override void Validate() { }

	public static bool TryParse(string userId, out GetActiveDivisions command)
	{
		if (string.IsNullOrWhiteSpace(userId))
		{
			command = null;
			return false;
		}

		command = new GetActiveDivisions(userId);
		return true;
	}
}
