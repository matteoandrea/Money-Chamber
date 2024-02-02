using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectS.Core.Core.Command;

namespace ProjectS.Api.Extensions;

public static class EndPointExtension
{
	public static WebApplication MediateGet<TRequest>(
		this WebApplication app,
		string template) where TRequest : IHttpsRequest
	{
		app.MapGet(template, async (
			IMediator mediator,
			[FromBody] TRequest request) => await mediator.Send(request));

		return app;
	}

	public static WebApplication MediatePost<TRequest>(
		this WebApplication app,
		string template) where TRequest : IHttpsRequest
	{
		app.MapPost(template, async (
			IMediator mediator,
			[FromBody] TRequest request) => await mediator.Send(request));

		return app;
	}

	public static WebApplication MediatePut<TRequest>(
		this WebApplication app,
		string template) where TRequest : IHttpsRequest
	{
		app.MapPut(template, async (
			IMediator mediator,
			[FromBody] TRequest request) => await mediator.Send(request));

		return app;
	}

	public static WebApplication MediateDelete<TRequest>(
		this WebApplication app,
		string template) where TRequest : IHttpsRequest
	{
		app.MapDelete(template, async (
			IMediator mediator,
			[FromBody] TRequest request) => await mediator.Send(request));

		return app;
	}
}
