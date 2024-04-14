using Core.HttpsRequest.Divisions;

namespace Api.Endpoints;

public static class DivisionEndpoints
{
	private static readonly string _headPath = "division/";

	public static void MapDivisionEndpoints(this WebApplication app, string version)
	{
		app.MediateGet<GetActiveDivisions>(string.Concat(_headPath, version, "getActives"));
	}
}
