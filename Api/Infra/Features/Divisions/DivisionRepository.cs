using Core.Models.Divisions;
using MongoDB.Driver;
using ProjectS.Core.Repositories;
using ProjectS.Infra.Core;

namespace ProjectS.Infra.Features.Users;

public class DivisionRepository(DataContext _context) : IDivisionRepository
{
	#region GET
	public async Task<ICollection<Division>> GetActiveDivisionsAsync(string userId)
	{
		return await _context.Divisions.Find(x => x.UserId == userId  && x.Active == true).ToListAsync();
	}
	#endregion

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}

	public async Task CreateAsync(Division division)
	{
		await _context.Divisions.InsertOneAsync(division);
	}

	public async Task CreateAsync(IEnumerable<Division> divisions)
	{
		await _context.Divisions.InsertManyAsync(divisions);
	}

	public async Task DeleteAllByUserIdAsync(string userId)
	{
		await _context.Divisions.DeleteManyAsync(x => x.Id == userId);
	}



}
