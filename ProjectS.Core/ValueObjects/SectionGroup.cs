using ProjectS.Core.Core.Objects;
using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.ValueObjects;

namespace ProjectS.Core.Shared.ValueObjects;

public class SectionGroup : ValueObject
{
    public SectionGroup(Name name, BasicMoneyDetail detail, IEnumerable<Section> sections)
    {
        Name = name;
        Detail = detail;
        Sections = sections;

        AddNotifications(Name, Detail);
    }

    public Name Name { get; init; }
    public BasicMoneyDetail Detail { get; init; }
    public IEnumerable<Section> Sections { get; init; }
}
