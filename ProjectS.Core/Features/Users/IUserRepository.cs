namespace Standard.Core.Features.Users;

public interface IUserRepository
{
	User GetByIdAsync(Guid id);
	void SaveAsync(User user);
}
