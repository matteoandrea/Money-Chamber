using ProjectS.Core.Models;

namespace ProjectS.Core.Repositories;

public interface IAccountRepository
{
	Task CreateAsync(Account account);
	Task CreateAsync(Account[] account);
}
