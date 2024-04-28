using Api.Endpoints;

namespace ProjectS.Api.Extensions;

public static class EndPointExtension
{
	public static void MapEndpoints(this WebApplication app)
	{
		app.MapAuthEndpoints("v1/");
		app.MapUserEndpoints("v1/");
		app.MapDivisionEndpoints("v1/");
	}
}
