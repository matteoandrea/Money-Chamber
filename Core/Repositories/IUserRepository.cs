using Core.Core;
using Core.ValueObjects;
using ProjectS.Core.Models;
using ProjectS.Core.Shared.ValueObjects;

namespace ProjectS.Core.Repositories;

public interface IUserRepository : IRepository
{
	Task<bool> AnyAsync(Email email);
	Task CreateAsync(User user);
	Task<User> GetByIdAsync(string id);
	Task<User> GetByEmailAsync(string email);
	Task UpdateTokenAsync(string userId, AuthToken tokens);
}
