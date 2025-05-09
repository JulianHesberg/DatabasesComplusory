using DatabasesComplusory.Application.Domain.Entities.Read;
using DatabasesComplusory.Application.Events.UserEvents;
using DatabasesComplusory.Application.Service;
using DatabasesComplusory.Infrastructure.Context;

namespace DatabasesComplusory.Application.Events.UserEventHandlers;

public class ReviewCreatedEventHandler
{
    private readonly MongoDbContext _mongo;
    private readonly CacheService _cache;

    public ReviewCreatedEventHandler(MongoDbContext mongo, CacheService cache) {
        _mongo = mongo;
        _cache = cache;
    }

    public void Handle(ReviewCreatedEvent evt)
    {
        var read = new ReviewRead
        {
            ReviewId = evt.ReviewId,
            UserId = evt.UserId,
            SellerId = evt.SellerId,
            Rating = evt.Rating,
            Comment = evt.Comment
        };
        _mongo.Reviews.InsertOne(read);
        _cache.CacheReviewAsync(read).Wait();
    }
}

