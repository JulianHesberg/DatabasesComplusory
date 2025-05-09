using DatabasesComplusory.Application.Commands.ReviewCommands;
using DatabasesComplusory.Application.Domain.Entities.Read;
using DatabasesComplusory.Application.Service;
using DatabasesComplusory.Domain.Interfaces;

namespace DatabasesComplusory.Application.ReviewCommandHandlers;

public class GetReviewByIdCommandHandler
{
    private readonly IReviewReadRepository _repo;
    private readonly CacheService _cache;
    public GetReviewByIdCommandHandler(IReviewReadRepository repo, CacheService cache)
    {
        _repo = repo;
        _cache = cache;
    }

    public async Task<ReviewRead> HandleAsync(GetReviewByIdCommand command)
    {
        ;
        var cached = await _cache.GetCachedReviewAsync(command.ReviewId);
        if (cached != null)
            return cached;

        var review = await _repo.GetByIdAsync(command.ReviewId);
        if (review == null)
            throw new KeyNotFoundException($"Review {command.ReviewId} not found");

        await _cache.CacheReviewAsync(review);
        return review;
    }
}