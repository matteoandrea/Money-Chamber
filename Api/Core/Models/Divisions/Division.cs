using ProjectS.Core.Core.Objects;
using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.Shared.ValueObjects;

namespace Core.Models.Divisions;

public class Division : Entity
{
	public Division(Season season, string userId)
	{
		Season = season;
		UserId = userId;
		Envelopes = [];

		AddNotifications(Season);
	}

	public Division(Season season,
				 string userId,
				 ICollection<Envelope> envelopes)
	{
		Season = season;
		UserId = userId;
		Envelopes = envelopes;

		AddNotifications(Season);
	}

	#region Properties
	public string UserId { get; init; }
	public virtual DivisionType Type { get; init; }
	public Season Season { get; init; }
	public ICollection<Envelope> Envelopes { get; init; }
	#endregion
}

public enum DivisionType
{
	Tribute = 0,
	Source = 1,
	Savings = 2
}