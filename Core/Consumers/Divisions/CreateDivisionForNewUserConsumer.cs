using Core.Commands;
using Core.Core;
using Core.Models.Divisions;
using MassTransit;
using ProjectS.Core.Repositories;
using ProjectS.Core.Shared.ValueObjects;
using System.Collections.Immutable;

namespace ProjectS.Core.Consumers.Divisions;

public class CreateDivisionForNewUserConsumer(IDivisionRepository _repository) : IConsumer<CreateDivisionForNewUser>
{
	#region Functions

	public async Task Consume(ConsumeContext<CreateDivisionForNewUser> context)
	{
		Season season = new(DateTime.Now);
		string id = context.Message.UserId;

		Division tribute = new Tribute(season, id);
		Division source = new Source(season, id);
		Division savings = new Savings(season, id);

		ImmutableArray<Division> divisions = [tribute, source, savings];

		try
		{
			await _repository.CreateAsync(divisions);
			await context.RespondAsync<GenericCommandResult>(new($"Divisions successfully created", 200));
		}
		catch
		{
			await context.RespondAsync<GenericCommandResult>(new("Fail to insert Divisions in database", 500));
		}
	}

	#endregion
}
