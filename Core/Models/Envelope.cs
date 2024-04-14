using Core.ValueObjects;
using ProjectS.Core.Core.Objects;
using ProjectS.Core.Shared.ValueObjects;
using ProjectS.Core.ValueObjects;

namespace ProjectS.Core.Features.Envelopes.Core;

public class Envelope : Entity
{
	public Envelope(string userId,
				 Name name,
				 Name tag,
				 MoneyDetails moneyDetails,
				 EnvelopeCycle cycle)
	{
		UserId = userId;
		Name = name;
		Tag = tag;
		MoneyDetails = moneyDetails;
		Cycle = cycle;

		AddNotifications(Name,
				   Tag,
				   MoneyDetails,
				   Cycle);
	}

	public string UserId { get; init; }
	public Name Name { get; init; }
	public Name Tag { get; init; }
	public MoneyDetails MoneyDetails { get; init; }
	public EnvelopeCycle Cycle { get; init; }
}
