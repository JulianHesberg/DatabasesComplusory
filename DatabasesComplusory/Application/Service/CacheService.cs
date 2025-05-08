using DatabasesComplusory.Domain.Entities.Read;
using Microsoft.Extensions.Caching.Memory;

namespace DatabasesComplusory.Application.Service;

public class CacheService
{
    private readonly IMemoryCache _cache;
    private static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromMinutes(10);

    public CacheService(IMemoryCache memoryCache)
    {
        _cache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
    }

    public Task CacheUserAsync(UserRead user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        var key = GetCacheKey(user.UserId);
        _cache.Set(key, user, DefaultCacheDuration);
        return Task.CompletedTask;
    }

    public Task<UserRead> GetCachedUserAsync(int userId)
    {
        var key = GetCacheKey(userId);
        _cache.TryGetValue(key, out UserRead user);
        return Task.FromResult(user);
    }

    public Task InvalidateCachedUserAsync(int userId)
    {
        _cache.Remove(GetCacheKey(userId));
        return Task.CompletedTask;
    }
    
    public Task CacheListingAsync(ListingRead listing)
    {
        if (listing == null) throw new ArgumentNullException(nameof(listing));

        var key = GetCacheKey(listing.ListingId);
        _cache.Set(key, listing, DefaultCacheDuration);
        return Task.CompletedTask;
    }
    
    public Task<ListingRead> GetCachedLystingAsync(int listingId)
    {
        var key = GetCacheKey(listingId);
        _cache.TryGetValue(key, out ListingRead listing);
        return Task.FromResult(listing);
    }

    private string GetCacheKey(int userId) => $"User:{userId}";
}