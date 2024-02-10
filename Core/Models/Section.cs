using ProjectS.Core.Core.Objects;
using ProjectS.Core.Models;
using ProjectS.Core.Shared.ValueObjects;
using ProjectS.Core.ValueObjects;

namespace ProjectS.Core.Features.Envelopes.Core;

public class Section : ValueObject
{
	public Section(Name name,
				BasicMoneyDetail moneyDetail,
				Cycle cycle,

				bool deletable = false)
	{
		Name = name;
		MoneyDetail = moneyDetail;
		Cycle = cycle;
		Deletable = deletable;

		AddNotifications(Name, MoneyDetail);
	}

	public Cycle Cycle { get; init; }
	public Name Name { get; init; }

	public BasicMoneyDetail MoneyDetail { get; init; }
	public ICollection<Account> Accounts { get; init; } = new List<Account>();

	public bool Deletable { get; init; }
}