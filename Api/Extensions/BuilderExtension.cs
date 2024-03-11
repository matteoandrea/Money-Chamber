using Core.Commands;
using Core.Consumers.Users;
using Core.HttpsRequest.Users;
using MassTransit;
using ProjectS.Core.Handlers.Envelopes;
using ProjectS.Core.Repositories;
using ProjectS.Infra.Core;
using ProjectS.Infra.Features.Users;

namespace ProjectS.Api.Extensions;

public static class BuilderExtension
{
	public static void AddArchitectures(this WebApplicationBuilder builder)
	{
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
	}

	public static void AddServices(this WebApplicationBuilder builder)
	{
		builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
		builder.Services.AddSingleton<DataContext>();

		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<IEnvelopeRepository, EnvelopeRepository>();
	}

	public static void AddConsumers(this WebApplicationBuilder builder)
	{
		builder.Services.AddMassTransit(busConfig =>
		{
			busConfig.SetKebabCaseEndpointNameFormatter();
			busConfig.UsingInMemory((context, config) => config.ConfigureEndpoints(context));

			busConfig.AddRequestClient<CreateUser>();
			busConfig.AddRequestClient<CreateNewUserEnvelopers>();

			busConfig.AddConsumer<CreateUserConsumer>();
			busConfig.AddConsumer<CreateNewUserEnvelopersConsumer>();
			busConfig.AddConsumer<CreateNewUserEnvelopersConsumerFail>();
		});
	}
}