using Standard.Core.Features.Users;
using Standard.Core.Shared.ValueObjects;

namespace Standard.Test.Features.Users;

[TestClass]
public class UserTest
{
    #region Valid Credentials

    private readonly Name _validName = new("Bruce", "Wayne");
    private readonly Email _validEmail = new("brucewayne@gmail.com");

    #endregion


    #region Invalid Credentials

    private readonly Name _invalidName = new("Bru", "");
    private readonly Email _invalidEmail = new("brucewayne.com");

    #endregion

    [TestMethod]
    [TestCategory("Core")]
    public void With_valid_credentials_Should_create_user()
    {
        User user = new(_validName, _validEmail);

        Assert.AreEqual(user.IsValid, true);
    }

    [TestMethod]
    [TestCategory("Core")]
    public void With_invalid_credentials_Should_not_create_user()
    {
        User user = new(_invalidName, _invalidEmail);

        Assert.AreEqual(user.IsValid, false);
    }

    [TestMethod]
    [TestCategory("Core")]
    public void With_invalid_name_Should_not_create_user()
    {
        User user = new(_invalidName, _validEmail);

        Assert.AreEqual(user.IsValid, false);
    }

    [TestMethod]
    [TestCategory("Core")]
    public void With_invalid_email_Should_not_create_user()
    {
        User user = new(_validName, _invalidEmail);

        Assert.AreEqual(user.IsValid, false);
    }
}
