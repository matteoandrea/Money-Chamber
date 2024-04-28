using Core.Models.Divisions;
using ProjectS.Core.Core.Objects;
using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.Models;

namespace ProjectS.Core.ValueObjects;

public class SubTransaction : ValueObject
{
	public SubTransaction(Envelope envelope, Division division, Account account, decimal totalAmount)
	{
		Envelope = envelope;
		this.Division = division;
		Account = account;
		TotalAmount = totalAmount;
	}

	public Envelope Envelope { get; init; }
	public Division Division { get; init; }
	public Account Account { get; init; }
	public decimal TotalAmount { get; init; }
}
