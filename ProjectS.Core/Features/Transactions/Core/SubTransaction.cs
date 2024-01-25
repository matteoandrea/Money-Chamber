using ProjectS.Core.Features.Accounts.Core;
using ProjectS.Core.Features.Envelopes.Core;
using Standard.Core.Shared.Core.Objects;

namespace ProjectS.Core.Features.Transactions.Core;

public class SubTransaction : ValueObject
{
	public SubTransaction(Envelope envelope, Section section, Account account, decimal totalAmount)
	{
		Envelope = envelope;
		Section = section;
		Account = account;
		TotalAmount = totalAmount;
	}

	public Envelope Envelope { get; init; }
	public Section Section { get; init; }
	public Account Account { get; init; }
	public decimal TotalAmount { get; init; }
}
