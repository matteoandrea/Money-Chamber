using Standard.Core.Shared.Core.Objects;
using Standard.Core.Shared.ValueObjects;

namespace ProjectS.Core.Features.Envelopes.Core;

public class Envelope : Entity
{
    public Envelope(
        Name name,
        EnvelopeType type,
        MoneyDetail details,
        IEnumerable<Section> sections,
		DateTime cycle
        )
    {
        Name = name;
        Type = type;
        Details = details;
        Sections = sections;
        Cycle = cycle;

        AddNotifications(Name, Details);
    }


    #region Propreties

    public Name Name { get; init; }
	public MoneyDetail Details { get; init; }

	public EnvelopeType Type { get; init; }
    public DateTime Cycle{ get; init; }

    public IEnumerable<Section> Sections { get; init; }

    #endregion
}
                                                