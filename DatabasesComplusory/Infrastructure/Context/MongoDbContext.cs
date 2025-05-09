using DatabasesComplusory.Application.Domain.Entities.Read;
using DatabasesComplusory.Domain.Entities.Read;
using DatabasesComplusory.Domain.Entities.Write;
using MongoDB.Driver;

namespace DatabasesComplusory.Infrastructure.Context;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    
    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
    
    public IMongoCollection<UserRead> Users => _database.GetCollection<UserRead>("Users");  
    public IMongoCollection<ListingRead> Listings => _database.GetCollection<ListingRead>("Listings");
    public IMongoCollection<ReviewRead> Reviews => _database.GetCollection<ReviewRead>("Reviews");
}