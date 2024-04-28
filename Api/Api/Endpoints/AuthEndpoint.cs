using Core.HttpsRequest.Auth;

namespace Api.Endpoints;

public static class AuthEndpoint
{
	private static readonly string _headPath = "auth/";

	public static void MapAuthEndpoints(this WebApplication app, string version)
	{
		app.MediatePost<PostLoginAuth>(string.Concat(_headPath, version, "login"));
	}
}
