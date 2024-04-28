using Core.Models.Divisions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectS.Core.Models;
using ProjectS.Infra.Features.Users;


namespace ProjectS.Infra.Core;

public class DataContext : DbContext
{
	public DataContext(IOptions<MongoDBSettings> options)
	{
		MongoClient client = new(options.Value.ConnectionString);
		Database = client.GetDatabase(options.Value.DatabaseName);

		Users = Database.GetCollection<User>(options.Value.UserCollectionName);
		Divisions = Database.GetCollection<Division>(options.Value.DivisionCollectionName);
	}

	public IMongoDatabase Database { get; }
	public IMongoCollection<User> Users { get; init; }
	public IMongoCollection<Division> Divisions { get; init; }
	
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfiguration(new UserMap());
		builder.ApplyConfiguration(new DivisionMap());
	}
}
