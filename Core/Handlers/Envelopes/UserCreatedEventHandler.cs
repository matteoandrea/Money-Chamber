using MediatR;
using ProjectS.Core.Events.Users;
using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.Repositories;
using ProjectS.Core.Shared.ValueObjects;
using ProjectS.Core.ValueObjects;

namespace ProjectS.Core.Handlers.Envelopes;

public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
	#region Contructors

	public UserCreatedEventHandler(IEnvelopeRepository repository, IMediator mediator)
	{
		_repository = repository;
		_mediator = mediator;
	}

	#endregion

	#region Propreties

	private readonly IEnvelopeRepository _repository;
	private readonly IMediator _mediator;

	#endregion

	#region Functions

	public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
	{

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
				new Name("Tribute"),
				EnvelopeType.Tribute,
				new BasicMoneyDetail(0, 0),
				season
								);

			food = new(
			   new Name("Food"),
			   EnvelopeType.Food,
			   new BasicMoneyDetail(0, 0),
			   season
			   );

			supply = new(
				new Name("Supply"),
				EnvelopeType.Supply,
				new BasicMoneyDetail(0, 0),
				season
				);

			saving = new(
				new Name("Savings"),
				EnvelopeType.Saving,
				new BasicMoneyDetail(0, 0),
				season
				);


			await _repository.CreateAsync([tribute, food, supply, saving]);
		}
		catch
		{

		}
	}

	#endregion
}
