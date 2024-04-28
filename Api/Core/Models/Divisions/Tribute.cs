using ProjectS.Core.Shared.ValueObjects;

namespace Core.Models.Divisions;
internal class Tribute(Season season, string userId) : Division(season, userId)
{
	public override DivisionType Type { get; init; } = DivisionType.Tribute;
}
