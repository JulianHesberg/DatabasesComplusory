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

    /// <summary>
    /// Retrieves a cached UserRead by ID, or null if not present.
    /// </summary>
    public Task<UserRead> GetCachedUserAsync(int userId)
    {
        var key = GetCacheKey(userId);
        _cache.TryGetValue(key, out UserRead user);
        return Task.FromResult(user);
    }

    /// <summary>
    /// Removes a UserRead from the cache.
    /// </summary>
    public Task InvalidateCachedUserAsync(int userId)
    {
        _cache.Remove(GetCacheKey(userId));
        return Task.CompletedTask;
    }

    private string GetCacheKey(int userId) => $"User:{userId}";
}