using ProjectS.Core.Features.Users.Core;
using Standard.Core.Shared.ValueObjects;

namespace ProjectS.Core.Features.Users.Handlers;

public interface IUserRepository
{
	Task<bool> AnyAsync(Email email);

	Task CreateAsync(User user);
	Task UpdateAsync(User user);
	Task DeleteAsync(User user);

	Task<User> GetByIdAsync(Guid id);
}
