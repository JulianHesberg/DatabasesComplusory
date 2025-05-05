using MongoDB.Driver;
using DatabasesComplusory.Models.Read;

namespace DatabasesComplusory.Data.Context;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    
    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
    
    public IMongoCollection<ListingRead> Listings => _database.GetCollection<ListingRead>("Listings");  
}