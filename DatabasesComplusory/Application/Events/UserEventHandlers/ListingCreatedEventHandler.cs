using DatabasesComplusory.Application.Service;
using DatabasesComplusory.Domain.Entities.Read;
using DatabasesComplusory.Infrastructure.Context;

namespace DatabasesComplusory.Application.Events.UserEventHandlers;

public class ListingCreatedEventHandler
{
    private readonly MongoDbContext _context;
    private readonly CacheService _cache;
    
    public ListingCreatedEventHandler(MongoDbContext context, CacheService cache)
    {
        _context = context;
        _cache = cache;
    }
    
    public void Handle(ListingCreatedEvent listingEvent)
    {
        var listing = new ListingRead
        {
            ListingId = listingEvent.ListingId,
            Name = listingEvent.Name,
            Description = listingEvent.Description,
            Price = listingEvent.Price,
            SellerId = listingEvent.SellerId,
            Quantity = listingEvent.Quantity,
            Media = listingEvent.Media
        };
        
        _context.Listings.InsertOne(listing);
        _cache.CacheListingAsync(listing).Wait();
    }
}