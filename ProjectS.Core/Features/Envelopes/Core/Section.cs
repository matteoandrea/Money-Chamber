using ProjectS.Core.Features.Accounts.Core;
using Standard.Core.Shared.Core.Objects;
using Standard.Core.Shared.ValueObjects;

namespace ProjectS.Core.Features.Envelopes.Core;

public class Section : ValueObject
{
	public Section(Name name, MoneyDetail moneyDetail, Cycle cycle, Account[] accounts, bool deletable = false)
	{
		Name = name;
		MoneyDetail = moneyDetail;
		Cycle = cycle;
		Accounts = accounts;
		Deletable = deletable;

		AddNotifications(Name, MoneyDetail);
	}

	public Name Name { get; init; }
	public MoneyDetail MoneyDetail { get; init; }
	public bool Deletable { get; init; }
	public Cycle Cycle { get; init; }
	public Account[] Accounts { get; init; }
}
