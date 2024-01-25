using Microsoft.EntityFrameworkCore;
using ProjectS.Core.Features.Users.Core;
using ProjectS.Infra.Maps;
using System.Reflection.Emit;

namespace ProjectS.Infra.Core;

public class DataContext(DbContextOptions options) : DbContext(options)
{
	public DbSet<User> Users { get; init; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfiguration(new UserMap());
	}


}
