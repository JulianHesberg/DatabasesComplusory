using DatabasesComplusory.Domain.Entities.Write;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DatabasesComplusory.Domain.Entities.Read;

[BsonIgnoreExtraElements]
public class UserRead
{
    [BsonId]
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Review> Reviews { get; set; }
}