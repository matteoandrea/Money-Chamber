using Core.Consumers.Users;
using Core.Core;
using Core.HttpsRequest.Users;
using FakeItEasy;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using ProjectS.Core.Handlers.Envelopes;
using ProjectS.Core.Repositories;
using ProjectS.Core.Shared.ValueObjects;

namespace Tests;

[TestClass]
public class CreateUserConsumerTests
{
	IUserRepository mockUser = new Fake<IUserRepository>().FakedObject;
	IEnvelopeRepository mockEnvelope = new Fake<IEnvelopeRepository>().FakedObject;

	private ServiceProvider CreateServiceProvider(IUserRepository mockUser, IEnvelopeRepository mockEnvelope)
	{
		return new ServiceCollection()
			.AddScoped(_ => mockUser)
			.AddScoped(_ => mockEnvelope)
			.AddMassTransitTestHarness(x =>
			{
				x.AddConsumer<CreateUserConsumer>();
				x.AddConsumer<CreateNewUserEnvelopersConsumer>();
			})
			.BuildServiceProvider(true);
	}

	[TestMethod]
	[DataRow("Tony", "Stark", "tonystark@avengers.com")]
	[DataRow("Natasha", "Romanoff", "natasharomanoff@shield.com")]
	[DataRow("Steve", "Rogers", "steverogers@shield.com")]
	public async Task Create_User_Sucess()
	{
		// Arrange
		Response<GenericCommandResult> response;
		CreateUser createUser = new(new FullName("Bruce", "Wayne"), new Email("brucewayne@gmail.com"));

		// Act
		await using (ServiceProvider provider = CreateServiceProvider(mockUser, mockEnvelope))
		{
			ITestHarness harness = provider.GetRequiredService<ITestHarness>();
			await harness.Start();

			IRequestClient<CreateUser> client = harness.GetRequestClient<CreateUser>();
			response = await client.GetResponse<GenericCommandResult>(createUser);
			var consumerHarness = harness.GetConsumerHarness<CreateUserConsumer>();

			await harness.Stop();
		}

		Assert.IsTrue(response.Message.Success);
	}

	[TestMethod]
	[DataRow("", "Wayne", "brucewayne@gmail.com", "Nome inválido")]
	[DataRow("Bruce", "", "brucewayne@gmail.com", "Sobrenome inválido")]
	[DataRow("Bruce", "Wayne", "brucewayne", "Email inválido")]
	[DataRow("Bruce", "Wayne", "brucewayne@invalido", "Email inválido")]
	public async Task Create_User_Fail()
	{
		// Arrange
		Response<GenericCommandResult> response;
		CreateUser createUser = new(new FullName("s", "s"), new Email("s.com"));

		// Act
		await using (ServiceProvider provider = CreateServiceProvider(mockUser, mockEnvelope))
		{
			ITestHarness harness = provider.GetRequiredService<ITestHarness>();
			await harness.Start();

			IRequestClient<CreateUser> client = harness.GetRequestClient<CreateUser>();
			response = await client.GetResponse<GenericCommandResult>(createUser);
			var consumerHarness = harness.GetConsumerHarness<CreateUserConsumer>();

			await harness.Stop();
		}

		Assert.IsFalse(response.Message.Success);
	}
}
