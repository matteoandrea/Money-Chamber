using Core.Auth;
using Core.Commands;
using Core.Consumers.Auth;
using Core.Consumers.Divisions;
using Core.Consumers.Users;
using Core.HttpsRequest.Auth;
using Core.HttpsRequest.Divisions;
using Core.HttpsRequest.Users;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjectS.Core.Consumers.Divisions;
using ProjectS.Core.Repositories;
using ProjectS.Infra.Core;
using ProjectS.Infra.Features.Users;
using System.Text;

namespace ProjectS.Api.Extensions;

public static class BuilderExtension
{
	public static void AddArchitectures(this WebApplicationBuilder builder)
	{
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddAuthentication(x =>
		{
			x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(x =>
		{
			var secret = builder.Configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException("JwtSettings:Secret não pode ser nulo ou vazio.");

			x.TokenValidationParameters = new TokenValidationParameters
			{
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
				ValidateIssuer = false,
				ValidateAudience = false,
			};
		});

		builder.Services.AddAuthorizationBuilder()
			.AddPolicy("Bearer", policy =>
			{
				policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
				policy.RequireAuthenticatedUser();
			});
	}

	public static void AddServices(this WebApplicationBuilder builder)
	{
		builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
		builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("Jwt"));
		
		builder.Services.AddSingleton<DataContext>();

		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<IDivisionRepository, DivisionRepository>();
		//builder.Services.AddScoped<IAccountRepository, AccountRepository>();
	}

	public static void AddRequestsAndConsumers(this WebApplicationBuilder builder)
	{
		builder.Services.AddMassTransit(busConfig =>
		{
			busConfig.SetKebabCaseEndpointNameFormatter();
			busConfig.UsingInMemory((context, config) => config.ConfigureEndpoints(context));

			busConfig.AddRequestClient<PostCreateUser>();
			busConfig.AddRequestClient<PostCreateUserFail>();
			busConfig.AddConsumer<PostCreateUserConsumer>();

			busConfig.AddRequestClient<CreateDivisionForNewUser>();
			busConfig.AddConsumer<CreateDivisionForNewUserConsumer>();
			busConfig.AddConsumer<CreateDivisionForNewUserConsumerFail>();

			busConfig.AddRequestClient<GetActiveDivisions>();
			busConfig.AddConsumer<GetActiveDivisionsConsumer>();

			busConfig.AddRequestClient<PostLoginAuth>();
			busConfig.AddConsumer<PostLoginAuthConsumer>();
		});
	}
}