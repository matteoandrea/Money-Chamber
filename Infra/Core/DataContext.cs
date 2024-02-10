using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectS.Core.Features.Envelopes.Core;
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
		Envelopes = Database.GetCollection<Envelope>(options.Value.EnvelopeCollectionName);
		//Users = Database.GetCollection<User>(options.Value.UserCollectionName);


	}

	public IMongoDatabase Database { get; }
	public IMongoCollection<User> Users { get; init; }
	public IMongoCollection<Envelope> Envelopes { get; init; }
	//public IMongoCollection<Tra> Envelopes { get; init; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfiguration(new UserMap());
		builder.ApplyConfiguration(new EnvelopeMap());
	}


}
