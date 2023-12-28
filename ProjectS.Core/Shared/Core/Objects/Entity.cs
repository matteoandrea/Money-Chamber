using Flunt.Notifications;

namespace Standard.Core.Shared.Core.Objects;

public class Entity : Notifiable<Notification>, IEquatable<Entity>
{
	public Entity()
	{
		Id = Guid.NewGuid();
		CreatedDate = DateTime.Now;
		Active = true;
	}

	public Guid Id { get; private set; }
	public DateTime CreatedDate { get; private set; }
	public bool Active { get; private set; }

	public bool Equals(Entity other)
	{
		return Id == other.Id;
	}
}
