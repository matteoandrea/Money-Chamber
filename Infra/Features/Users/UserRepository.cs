using Core.ValueObjects;
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
		return await _context.Users
			.FindSync(x => x.Email == email)
			.AnyAsync();
	}

	public async Task CreateAsync(User user)
	{
		await _context.Users.InsertOneAsync(user);
	}

	public async Task<User> GetByIdAsync(string id)
	{
		return await _context.Users
			.Find(x => x.Id == id)
			.FirstAsync();
	}

	public async Task<User> GetByEmailAsync(string email)
	{
		return await _context.Users
			.Find(x => x.Email.Address == email)
			.FirstAsync();
	}

	public async Task UpdateTokenAsync(string userId, AuthToken tokens)
	{
		FilterDefinition<User> filter = Builders<User>.Filter.Eq(x => x.Id, userId);
		UpdateDefinition<User> updatedValue = Builders<User>.Update
					.Set(x => x.AuthToken, tokens);
		await _context.Users.UpdateOneAsync(filter, updatedValue);
	}

	#endregion
}

