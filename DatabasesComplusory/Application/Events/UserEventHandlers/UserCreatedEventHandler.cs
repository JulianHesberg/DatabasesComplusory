using DatabasesComplusory.Application.Service;
using DatabasesComplusory.Domain.Entities.Read;
using DatabasesComplusory.Infrastructure.Context;

namespace DatabasesComplusory.Application.Events.UserEventHandlers;

public class UserCreatedEventHandler
{
    private readonly MongoDbContext _context;
    private readonly CacheService _cache;
    
    public UserCreatedEventHandler(MongoDbContext context, CacheService cache)
    {
        _context = context;
        _cache = cache;
    }
    
    public void Handle(UserCreatedEvent userCreatedEvent)
    {
        var user = new UserRead
        {
            UserId = userCreatedEvent.UserId,
            Name = userCreatedEvent.Name,
            Email = userCreatedEvent.Email,
        };
        
        _context.Users.InsertOne(user);
        
        _cache.CacheUserAsync(user).Wait();
    }
}