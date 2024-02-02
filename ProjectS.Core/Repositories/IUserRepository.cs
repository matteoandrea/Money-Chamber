using ProjectS.Core.Core.Command;
using ProjectS.Core.Models;
using ProjectS.Core.Shared.ValueObjects;

namespace ProjectS.Core.Repositories;

public interface IUserRepository : IRepository
{
	Task<bool> AnyAsync(Email email);

	Task CreateAsync(User user);
	Task UpdateAsync(User user);
	Task DeleteAsync(Guid id);

	Task<User?> GetByIdAsync(Guid id);
}
