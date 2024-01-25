using ProjectS.Core.Features.Users.Core;
using ProjectS.Core.Features.Users.Handlers;
using Standard.Core.Shared.ValueObjects;

namespace ProjectS.Infra.Features.Users;

public class UserRepository : IUserRepository
{
	#region Constructors

	public UserRepository(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	#endregion

	#region Propreties

	private readonly IUserRepository _userRepository;

	#endregion

	#region Functions

	public Task<bool> AnyAsync(Email email)
	{
		throw new NotImplementedException();
	}

	public Task CreateAsync(User user)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(User user)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(User user)
	{
		throw new NotImplementedException();
	}

	public Task<User> GetByIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	#endregion
}
