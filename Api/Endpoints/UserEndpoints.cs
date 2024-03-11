using Core.HttpsRequest.Users;

namespace Api.Endpoints;

public static class UserEndpoints
{
	public static void MapUserEndpoints(this WebApplication app)
	{
		app.MediatePost<CreateUser>("user/v1/create/{user}");
	}

}
