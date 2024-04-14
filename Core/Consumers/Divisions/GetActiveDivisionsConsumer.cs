using Core.Core;
using Core.HttpsRequest.Divisions;
using Core.Models.Divisions;
using MassTransit;
using ProjectS.Core.Repositories;

namespace Core.Consumers.Divisions;

public class GetActiveDivisionsConsumer(IDivisionRepository repository) : IConsumer<GetActiveDivisions>
{
	private readonly IDivisionRepository _repository = repository;

	public async Task Consume(ConsumeContext<GetActiveDivisions> context)
	{
		try
		{
			ICollection<Division> divisions = await _repository.GetActiveDivisionsAsync(context.Message.UserId);
			
			if (divisions == null)
			{
				await context.RespondAsync<GenericCommandResult>(new("null", 500));
				return;
			}
			await context.RespondAsync<GenericCommandResult>(new("Done", 200, divisions.ToList()));
		}
		catch
		{
			await context.RespondAsync<GenericCommandResult>(new("Fail to get data from database", 500));
		}
	}
}
