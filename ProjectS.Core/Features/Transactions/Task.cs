using Standard.Core.Features.Categories;
using Standard.Core.Features.Users;
using Standard.Core.Shared.Core.Objects;
using Standard.Core.Shared.ValueObjects;

namespace Standard.Core.Features.Tasks;

public class Task : Entity
{
	public Task(Description description, Category category)
	{
		Description = description;
		Category = category;
		Done = false;
		Users = new List<User>();

		AddNotifications(Description, Category);
	}

	public bool Done { get; private set; }
	public Description Description { get; private set; }
	public Category Category { get; private set; }
	public ICollection<User> Users { get; private set; }


	public void MarkAsDone()
	{
		Done = true;
	}

	public void MarkAsUndone()
	{
		Done = false;
	}

	public void UpdateDescription(Description description)
	{
		if (description.IsValid)
			Description = description;
	}
}
