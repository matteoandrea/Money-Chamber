using ProjectS.Core.Features.Accounts.Core;

namespace ProjectS.Core.Features.Accounts.Handlers;

public interface IAccountRepository
{
	Task CreateAsync(Account account);
	Task CreateAsync(Account[] account);
}
