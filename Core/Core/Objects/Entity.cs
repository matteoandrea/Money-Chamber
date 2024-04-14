using Flunt.Notifications;

namespace ProjectS.Core.Core.Objects;

public abstract class Entity : Notifiable<Notification>, IEquatable<Guid>
{
	#region Constructors

	protected Entity(string id,
				  bool active,
				  DateTime creationDate)
	{
		Id = id;
		Active = active;
		CreationDate = creationDate;
	}

	protected Entity(string id)
	{
		Id = id;
		Active = true;
		CreationDate = DateTime.UtcNow;
	}

	public Entity()
	{
		Id = Guid.NewGuid().ToString();
		Active = true;
		CreationDate = DateTime.UtcNow;
	}

	#endregion

	#region Propreties

	public string Id { get; init; }
	public bool Active { get; init; }
	public DateTime CreationDate { get; init; }

	#endregion

	#region Functions

	public bool Equals(Guid id) => Id == Id;

	public override int GetHashCode() => Id.GetHashCode();

	#endregion
}
