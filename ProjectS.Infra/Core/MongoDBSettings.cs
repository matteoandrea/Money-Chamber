using MongoDB.Driver;

namespace ProjectS.Infra.Core;

public class MongoDBSettings

{
	public string ConnectionString { get; set; } = null!;
	public string DatabaseName { get; set; } = null!;
	public string UserCollectionName { get; set; } = null!;
}
