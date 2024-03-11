using MongoDB.Driver;
using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.Repositories;
using ProjectS.Infra.Core;

namespace ProjectS.Infra.Features.Users;

public class EnvelopeRepository(DataContext _context) : IEnvelopeRepository
{
	#region Functions

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}

	public async Task CreateAsync(Envelope envelope)
	{
		await _context.Envelopes.InsertOneAsync(envelope);
	}

	public async Task CreateAsync(IEnumerable<Envelope> envelopes)
	{
		await _context.Envelopes.InsertManyAsync(envelopes);
	}

	public async Task DeleteAllByUserIdAsync(Guid userId)
	{
		FilterDefinition<Envelope> filter = Builders<Envelope>.Filter.Eq("UserId", userId);
		await _context.Envelopes.DeleteManyAsync(filter);
	}

	#endregion
}
