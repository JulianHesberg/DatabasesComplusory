using DatabasesComplusory.Application.Service;
using DatabasesComplusory.Domain.Entities.Read;
using DatabasesComplusory.Domain.Interfaces;

namespace DatabasesComplusory.Application.Commands.UserCommandHandlers;

public class GetUserCommandHandler
{
    private readonly CacheService _cache;
    private readonly IUserReadRepository _repo;

    public GetUserCommandHandler(CacheService cache, IUserReadRepository repo)
    {
        _cache = cache;
        _repo = repo;
    }

    public async Task<UserRead> HandleAsync(GetUserCommand command)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));

        //try Redis cache
        var cached = await _cache.GetCachedUserAsync(command.UserId);
        if (cached != null)
            return cached;

        //fall back to Mongo
        var user = await _repo.GetByIdAsync(command.UserId);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {command.UserId} not found.");

        //re‐cache and return
        await _cache.CacheUserAsync(user);
        return user;
    }
}