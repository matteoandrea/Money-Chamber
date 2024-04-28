using Core.HttpsRequest.Users;

namespace Api.Endpoints;

public static class UserEndpoints
{
	private static readonly string _headPath = "user/";
	public static void MapUserEndpoints(this WebApplication app, string version)
	{
		app.MediatePost<PostCreateUser>(string.Concat(_headPath, version, "create"));
	}

}
