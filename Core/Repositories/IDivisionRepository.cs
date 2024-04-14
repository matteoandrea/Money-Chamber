using Core.Core;
using Core.Models.Divisions;

namespace ProjectS.Core.Repositories;

public interface IDivisionRepository : IRepository
{
	Task<ICollection<Division>> GetActiveDivisionsAsync(string userId);
	Task CreateAsync(Division division);
	Task CreateAsync(IEnumerable<Division> divisions);
	Task DeleteAllByUserIdAsync(string userId);
}
