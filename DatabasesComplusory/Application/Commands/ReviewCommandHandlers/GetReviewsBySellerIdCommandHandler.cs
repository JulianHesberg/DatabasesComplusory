using DatabasesComplusory.Application.Domain.Entities.Read;
using DatabasesComplusory.Application.Service;
using DatabasesComplusory.Domain.Interfaces;

namespace DatabasesComplusory.Application.Commands.ReviewCommands;

public class GetReviewsBySellerCommandHandler
{
    private readonly IReviewReadRepository _repo;
    private readonly CacheService _cache;

    public GetReviewsBySellerCommandHandler(IReviewReadRepository repo, CacheService cache)
    {
        _repo = repo;
        _cache = cache;
    }


    public async Task<List<ReviewRead>> HandleAsync(GetReviewsBySellerIdCommand command)
    {

        var cached = await _cache.GetCachedReviewsBySellerAsync(command.SellerId);
        if (cached != null && cached.Count > 0)
            return cached;

        var reviews = await _repo.GetBySellerIdAsync(command.SellerId);
        if (reviews == null || reviews.Count == 0)
            return reviews;

        
        await _cache.CacheReviewsBySellerAsync(command.SellerId, reviews);
        return reviews;
    }
}