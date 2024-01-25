using Flunt.Notifications;

namespace Standard.Core.Shared.Core.Objects;

public abstract class Entity : Notifiable<Notification>, IEquatable<Guid>
{
	#region Constructors

	public Entity()
	{
		Id = Guid.NewGuid();
		Active = true;
		CreationDate = DateTime.UtcNow;
	}

	#endregion

	#region Propreties

	public Guid Id { get; init; }
	public bool Active { get; init; }
	public DateTime CreationDate { get; init; }

	#endregion

	#region Functions

	public bool Equals(Guid id) => Id == Id;

	public override int GetHashCode() => Id.GetHashCode();

	#endregion
}
