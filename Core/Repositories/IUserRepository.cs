using Core.Core;
using ProjectS.Core.Models;
using ProjectS.Core.Shared.ValueObjects;

namespace ProjectS.Core.Repositories;

public interface IUserRepository : IRepository
{
	Task<bool> AnyAsync(Email email);
	Task CreateAsync(User user);
	Task<User?> GetByIdAsync(Guid id);
}
