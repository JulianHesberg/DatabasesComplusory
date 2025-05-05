using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabasesComplusory.Models.Read;

[BsonIgnoreExtraElements]
public class ListingRead
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int SellerId { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
}