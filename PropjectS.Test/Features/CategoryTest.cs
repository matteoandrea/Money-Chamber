using Standard.Core.Features.Categories;
using Standard.Core.Shared.ValueObjects;

namespace Standard.Test.Features;

[TestClass]
public class CategoryTest
{
	#region Valid Credentials

	private readonly Description _validDescription = new("Shopping");
	
	#endregion

	#region Invalid Credentials

	private readonly Description _invalidDescription = new("sh");

	#endregion

	[TestMethod]
	[TestCategory("Core")]
	public void With_valid_credentials_Should_create_category()
	{
		Category category = new(_validDescription);

		Assert.AreEqual(category.IsValid, true);
	}

	[TestMethod]
	[TestCategory("Core")]
	public void With_invalid_credentials_Should_not_create_category()
	{
		Category category = new(_invalidDescription);

		Assert.AreEqual(category.IsValid, false);
	}
}
