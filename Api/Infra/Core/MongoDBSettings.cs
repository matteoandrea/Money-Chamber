namespace ProjectS.Infra.Core;

public class MongoDBSettings

{
	public string ConnectionString { get; set; } = null!;
	public string DatabaseName { get; set; } = null!;
	public string UserCollectionName { get; set; } = null!;
	public string DivisionCollectionName { get; set; } = null!;
	public string TransactionCollectionName { get; set; } = null!;
}
