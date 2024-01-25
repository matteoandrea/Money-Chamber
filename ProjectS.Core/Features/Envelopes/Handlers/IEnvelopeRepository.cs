using ProjectS.Core.Features.Envelopes.Core;
using ProjectS.Core.Features.Users.Core;

namespace ProjectS.Core.Features.Envelopes.Handlers;

public interface IEnvelopeRepository
{
	Task CreateAsync(Envelope envelope);
	Task CreateAsync(Envelope[] envelopes);
}
