using Core.Commands;
using Core.Core;
using MassTransit;
using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.Repositories;
using ProjectS.Core.Shared.ValueObjects;
using ProjectS.Core.ValueObjects;

namespace ProjectS.Core.Handlers.Envelopes;

public class CreateNewUserEnvelopersConsumer(IEnvelopeRepository _repository) : IConsumer<CreateNewUserEnvelopers>
{
	#region Functions

	public async Task Consume(ConsumeContext<CreateNewUserEnvelopers> context)
	{
		CreateNewUserEnvelopers request = context.Message;

		Envelope tribute;
		Envelope food;
		Envelope supply;
		Envelope saving;

		try
		{
			DateTime today = DateTime.Today;
			DateTime nextMonthDay = today.
				AddMonths(1).
				AddDays(-1);

			Season season = new(today, nextMonthDay);

			tribute = new(
				request.UserId,
				new Name("Tribute"),
				EnvelopeType.Tribute,
				new BasicMoneyDetail(0, 0),
				season
				);

			food = new(
				request.UserId,
				new Name("Food"),
				EnvelopeType.Food,
				new BasicMoneyDetail(0, 0),
				season
				);

			supply = new(
				request.UserId,
				new Name("Supply"),
				EnvelopeType.Supply,
				new BasicMoneyDetail(0, 0),
				season
				);

			saving = new(
				request.UserId,
				new Name("Savings"),
				EnvelopeType.Saving,
				new BasicMoneyDetail(0, 0),
				season
				);


			Envelope[] envelopes = [tribute, food, supply, saving];

			await _repository.CreateAsync(envelopes);
			await context.RespondAsync<GenericCommandResult>(new($"Envelopes successfully created", 200, envelopes));
		}
		catch
		{
			await context.RespondAsync<GenericCommandResult>(new("Fail to insert envelopes in database", 500));
		}
	}

	#endregion
}
