using Core.Consumers.Users;
using Core.Core;
using Core.HttpsRequest.Users;
using Core.ValueObjects;
using FakeItEasy;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using ProjectS.Core.Consumers.Divisions;
using ProjectS.Core.Repositories;
using ProjectS.Core.Shared.ValueObjects;

namespace Tests.Consumers.Users;

[TestClass]
public class CreateUserConsumerTests
{
    readonly IUserRepository mockUser = new Fake<IUserRepository>().FakedObject;
    readonly IDivisionRepository mockEnvelope = new Fake<IDivisionRepository>().FakedObject;

    private ServiceProvider CreateServiceProvider(IUserRepository mockUser, IDivisionRepository mockEnvelope)
    {
        return new ServiceCollection()
            .AddScoped(_ => mockUser)
            .AddScoped(_ => mockEnvelope)
            .AddMassTransitTestHarness(x =>
            {
                x.AddConsumer<PostCreateUserConsumer>();
                x.AddConsumer<CreateDivisionForNewUserConsumer>();
            })
            .BuildServiceProvider(true);
    }

    [TestMethod]
    [DataRow("Tony", "Stark", "tonystark@avengers.com", "12341234")]
    [DataRow("Natasha", "Romanoff", "natasharomanoff@shield.com", "gsafdasfd")]
    [DataRow("Steve", "Rogers", "steverogers@shield.com", "wqeqweqweqweqwe")]
    public async Task Create_User_Sucess(string firstName, string lastName, string email, string password)
    {
        // Arrange
        Response<GenericCommandResult> response;
        PostCreateUser createUser = new(new FullName(firstName, lastName), new Email(email), new PasswordRequest(password));

        // Act
        await using (ServiceProvider provider = CreateServiceProvider(mockUser, mockEnvelope))
        {
            ITestHarness harness = provider.GetRequiredService<ITestHarness>();
            await harness.Start();

            IRequestClient<PostCreateUser> client = harness.GetRequestClient<PostCreateUser>();
            response = await client.GetResponse<GenericCommandResult>(createUser);
            var consumerHarness = harness.GetConsumerHarness<PostCreateUserConsumer>();

            await harness.Stop();
        }

        Assert.IsTrue(response.Message.Success);
    }

    [TestMethod]
    [DataRow("", "Wayne", "brucewayne@gmail.com", "asfafaf", "New User Invalid")]
    [DataRow("Bruce", "", "brucewayne@gmail.com", "1232134131", "New User Invalid")]
    [DataRow("Bruce", "Wayne", "brucewayne", "dawujisn", "New User Invalid")]
    [DataRow("Bruce", "Wayne", "brucewayne@invalido", "feikaw", "New User Invalid")]
    public async Task Create_User_Fail(string firstName, string lastName, string email, string password, string errorMessage)
    {
        // Arrange
        Response<GenericCommandResult> response;
        PostCreateUser createUser = new(new FullName(firstName, lastName), new Email(email), new PasswordRequest(password));

        // Act
        await using (ServiceProvider provider = CreateServiceProvider(mockUser, mockEnvelope))
        {
            ITestHarness harness = provider.GetRequiredService<ITestHarness>();
            await harness.Start();

            IRequestClient<PostCreateUser> client = harness.GetRequestClient<PostCreateUser>();
            response = await client.GetResponse<GenericCommandResult>(createUser);
            var consumerHarness = harness.GetConsumerHarness<PostCreateUserConsumer>();

            await harness.Stop();
        }

        Assert.IsFalse(response.Message.Success);
        Assert.AreEqual(response.Message.Message, errorMessage);
    }
}
