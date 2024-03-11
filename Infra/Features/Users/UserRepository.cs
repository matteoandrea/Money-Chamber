using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using ProjectS.Core.Models;
using ProjectS.Core.Repositories;
using ProjectS.Core.Shared.ValueObjects;
using ProjectS.Infra.Core;

namespace ProjectS.Infra.Features.Users;

public class UserRepository(DataContext _context) : IUserRepository
{
	#region Functions

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}

	public async Task<bool> AnyAsync(Email email)
	{
		return await _context.Users.FindSync(x => x.Email == email).AnyAsync();

	}

	public async Task CreateAsync(User user)
	{
		await _context.Users.InsertOneAsync(user);
	}

	public Task UpdateAsync(User user)
	{
		throw new NotImplementedException();
	}

	public async Task DeleteAsync(Guid id)
	{
		FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
		await _context.Users.DeleteOneAsync(filter);
	}

	public async Task<User?> GetByIdAsync(Guid id)
	{
		return await _context.Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
	}

	#endregion
}
