using ProjectS.Core.ValueObjects;

namespace ProjectS.Core.Shared.ValueObjects;
public class SectionMoneyDetail : BasicMoneyDetail
{
    public SectionMoneyDetail(decimal available, decimal allocated) : base(available, allocated)
    {
    }
}

