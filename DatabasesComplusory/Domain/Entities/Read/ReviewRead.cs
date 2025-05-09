using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabasesComplusory.Application.Domain.Entities.Read;

[BsonIgnoreExtraElements]
public class ReviewRead
{
    public int ReviewId { get; set; }
    public int UserId { get; set; }
    public int SellerId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}