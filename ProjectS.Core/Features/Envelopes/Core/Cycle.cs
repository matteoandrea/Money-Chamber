using Standard.Core.Shared.Core.Objects;

namespace ProjectS.Core.Features.Envelopes.Core;

public class Cycle : ValueObject
{
    public Cycle(CycleType type, DateTime date, decimal taget)
    {
        Type = type;
        Date = date;
        Taget = taget;
    }

    public Cycle(DateTime date, decimal taget)
    {
        Type = CycleType.Undefined;
        Date = date;
        Taget = taget;
    }

    public Cycle(decimal taget)
    {
        Type = CycleType.Undefined;
        Date = null;
        Taget = taget;
    }

    public CycleType Type { get; init; }
    public DateTime? Date { get; init; }
    public decimal Taget { get; init; }
}
