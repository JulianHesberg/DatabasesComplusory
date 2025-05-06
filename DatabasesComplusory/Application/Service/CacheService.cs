using DatabasesComplusory.Domain.Entities.Read;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace DatabasesComplusory.Application.Service;

public class CacheService
{
    private readonly IDatabase _cache;
    
    public CacheService(IConnectionMultiplexer redisConnection)  
    {  
        _cache = redisConnection.GetDatabase();  
    }  

    public async Task CacheUserAsync(UserRead user)
    {
        var serializedUser = JsonConvert.SerializeObject(user);
        await _cache.StringSetAsync(GetCacheKey(user.UserId), serializedUser);
    }
    
    public async Task<UserRead> GetCachedUserAsync(int userId)  
    {  
        var cachedUser = await _cache.StringGetAsync(GetCacheKey(userId));  
        return cachedUser.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<UserRead>(cachedUser);  
    }  
    
    public async Task InvalidateCachedUserAsync(int userId)  
    {  
        await _cache.KeyDeleteAsync(GetCacheKey(userId));  
    }  
    private string GetCacheKey(int userId)  
    {  
        return $"User:{userId}";  
    }  
}