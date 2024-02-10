using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.Repositories;
using ProjectS.Infra.Core;

namespace ProjectS.Infra.Features.Users;

public class EnvelopeRepository : IEnvelopeRepository
{
	#region Constructors

	public EnvelopeRepository(DataContext context)
	{
		_context = context;
	}

	#endregion

	#region Propreties

	private readonly DataContext _context;

	#endregion

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

	#endregion
}
