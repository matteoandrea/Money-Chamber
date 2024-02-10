using ProjectS.Core.Core.Objects;
using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.Models;

namespace ProjectS.Core.ValueObjects;

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
