using Core.Core;
using MassTransit;

namespace Api.Endpoints;

public static class EndPointConfig
{
	public static WebApplication MediateGet<TRequest>(
this WebApplication app,
string template) where TRequest : class, IHttpsRequest
	{
		app.MapGet(template, async (
			IRequestClient<TRequest> request,
			TRequest command) => await request.GetResponse<GenericCommandResult>(command));

		return app;
	}

	public static WebApplication MediatePost<TRequest>(
	this WebApplication app,
	string template) where TRequest : class, IHttpsRequest
	{
		app.MapPost(template, async (
			IRequestClient<TRequest> request,
			TRequest command) => await request.GetResponse<GenericCommandResult>(command));

		return app;
	}


	public static WebApplication MediatePut<TRequest>(
	this WebApplication app,
	string template) where TRequest : class, IHttpsRequest
	{
		app.MapPut(template, async (
			IRequestClient<TRequest> request,
			TRequest command) => await request.GetResponse<GenericCommandResult>(command));

		return app;
	}

	public static WebApplication MediateDelete<TRequest>(
	this WebApplication app,
	string template) where TRequest : class, IHttpsRequest
	{
		app.MapDelete(template, async (
			IRequestClient<TRequest> request,
			TRequest command) => await request.GetResponse<GenericCommandResult>(command));

		return app;
	}
}
