using ProjectS.Core.Shared.ValueObjects;

namespace Core.Models.Divisions;

internal class Savings(Season season, string userId) : Division(season, userId)
{
	public override DivisionType Type { get; init; } = DivisionType.Savings;
};

