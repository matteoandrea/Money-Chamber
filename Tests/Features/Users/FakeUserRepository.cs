using Standard.Core.Features.Users;
using Standard.Core.Shared.ValueObjects;

namespace Standard.Test.Features.Users;

internal class FakeUserRepository : IUserRepository
{
	public User GetByIdAsync(Guid id)
	{
		if (id == new Guid("3f72497b-188f-4d3a-92a1-c7432cfae62a"))
			return new(new Name("Bruce", "Wayne"), new Email("brucewayne@gmail.com"));

		return new(new Name("?????", "??????"), new Email("idontknow@gmail.com"));

	}

	public void SaveAsync(User user)
	{
		//throw new NotImplementedException();
	}
}
