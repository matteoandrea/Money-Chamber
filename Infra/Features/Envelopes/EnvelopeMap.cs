using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using ProjectS.Core.Features.Envelopes.Core;

namespace ProjectS.Infra.Features.Users;

internal class EnvelopeMap : IEntityTypeConfiguration<Envelope>
{
	public void Configure(EntityTypeBuilder<Envelope> builder)
	{
		builder.ToCollection("Envelopes");
		builder.HasKey(x => x.Id);
	}
}
