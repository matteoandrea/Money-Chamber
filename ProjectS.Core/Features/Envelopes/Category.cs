using Standard.Core.Shared.Core.Objects;
using Standard.Core.Shared.ValueObjects;

namespace Standard.Core.Features.Categories;

public class Category : Entity
{
	public Category(Description description)
	{
		Description = description;

		AddNotifications(Description);
	}

	public Description Description { get; private set; }
	public ICollection<Task> Tasks { get; private set; } = new List<Task>();
}
