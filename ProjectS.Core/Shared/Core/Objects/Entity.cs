using Flunt.Notifications;

namespace Standard.Core.Shared.Core.Objects;

public abstract class Entity : Notifiable<Notification>, IEquatable<Guid>
{
	public Entity()
	{
		Id = Guid.NewGuid();
	}

	public Guid Id { get; }

	public bool Equals(Guid id) => Id == Id;

	public override int GetHashCode() => Id.GetHashCode();
}
