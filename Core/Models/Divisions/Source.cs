using ProjectS.Core.Shared.ValueObjects;

namespace Core.Models.Divisions;

internal class Source(Season season, string userId) : Division(season, userId)
{
	public override DivisionType Type { get; init; } = DivisionType.Source;
}
