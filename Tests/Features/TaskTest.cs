using Standard.Core.Shared.ValueObjects;
using Task = Standard.Core.Features.Tasks.Task;

namespace Standard.Test.Features;

[TestClass]
public class TaskTest
{
	#region Valid Credentials

	private readonly Description _validTaskDescription = new("You need to buy milk");
	private readonly Description _validCategoryDescription = new("Shopping");


	#endregion


	#region Invalid Credentials

	private readonly Description _invalidTaskDescription = new("by");
	private readonly Description _invalidCategoryDescription = new("sh");

	#endregion

	[TestMethod]
	[TestCategory("Core")]
	public void With_valid_credentials_Should_create_task()
	{
		Task task = new(_validTaskDescription, new(_validCategoryDescription));

		Assert.AreEqual(task.IsValid, true);
	}

	[TestMethod]
	[TestCategory("Core")]
	public void With_invalid_credentials_Should_not_create_task()
	{
		Task task = new(_invalidTaskDescription, new(_invalidCategoryDescription));
		Console.WriteLine(task);

		Assert.AreEqual(task.IsValid, false);
	}

	[TestMethod]
	[TestCategory("Core")]
	public void With_invalid_task_description_Should_not_create_task()
	{
		Task task = new(_invalidTaskDescription, new(_validCategoryDescription));

		Assert.AreEqual(task.IsValid, false);
	}

	[TestMethod]
	[TestCategory("Core")]
	public void With_invalid_category_description_Should_not_create_task()
	{
		Task task = new(_validTaskDescription, new(_invalidCategoryDescription));

		Assert.AreEqual(task.IsValid, false);
	}
}
