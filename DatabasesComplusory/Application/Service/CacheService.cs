using DatabasesComplusory.Application.Domain.Entities.Read;
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

    public Task CacheReviewAsync(ReviewRead review)
    {
        if (review == null) throw new ArgumentNullException(nameof(review));
        _cache.Set(GetCacheKey(review.ReviewId), review, DefaultCacheDuration);
        return Task.CompletedTask;
    }

    public Task<ReviewRead> GetCachedReviewAsync(int reviewId)
    {
        _cache.TryGetValue(GetCacheKey(reviewId), out ReviewRead review);
        return Task.FromResult(review);
    }

    public Task CacheReviewsBySellerAsync(int sellerId, List<ReviewRead> reviews)
    {
        if (reviews == null) throw new ArgumentNullException(nameof(reviews));
        var key = GetCacheKey(sellerId);
        _cache.Set(key, reviews, DefaultCacheDuration);
        return Task.CompletedTask;
    }

    public Task<List<ReviewRead>> GetCachedReviewsBySellerAsync(int sellerId)
    {
        var key = GetCacheKey(sellerId);
        _cache.TryGetValue(key, out List<ReviewRead> reviews);
        return Task.FromResult(reviews);
    }

    private string GetCacheKey(int userId) => $"User:{userId}";
}