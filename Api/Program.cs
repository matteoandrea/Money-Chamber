using Microsoft.EntityFrameworkCore;
using ProjectS.Api.Extensions;
using ProjectS.Core.Handlers.Users;
using ProjectS.Core.Repositories;
using ProjectS.Core.Requests;
using ProjectS.Infra.Core;
using ProjectS.Infra.Features.Users;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	// DATABASE
	builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
	builder.Services.AddSingleton<DataContext>();

	builder.Services.AddScoped<IUserRepository, UserRepository>();
	builder.Services.AddScoped<IEnvelopeRepository, EnvelopeRepository>();

	builder.Services.AddMediatR(x =>
	{
		x.RegisterServicesFromAssemblyContaining<CreateUserHandler>();
		//x.RegisterServicesFromAssemblyContaining<AnotherHandler>(); // Example
	});





	//builder.Services.AddScoped<IUserRepository>();
	//builder.Services.AddScoped<IEnvelopeRepository>();



}

var app = builder.Build();
{
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();

	app.MediatePost<CreateUserRequest>("user/v1/create/{user}");


	app.Run();
}


