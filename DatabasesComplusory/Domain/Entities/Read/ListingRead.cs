using DatabasesComplusory.Domain.Entities.Write;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabasesComplusory.Domain.Entities.Read;

[BsonIgnoreExtraElements]
public class ListingRead
{
    [BsonId]
    public int ListingId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int SellerId { get; set; }
    public int Quantity { get; set; }
    public List<Media> Media { get; set; }
}