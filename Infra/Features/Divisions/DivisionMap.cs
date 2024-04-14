using Core.Models.Divisions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ProjectS.Infra.Features.Users;

internal class DivisionMap : IEntityTypeConfiguration<Division>
{
	public void Configure(EntityTypeBuilder<Division> builder)
	{
		builder.ToCollection("Divisions");
		builder.HasKey(x => x.Id);
	}
}
