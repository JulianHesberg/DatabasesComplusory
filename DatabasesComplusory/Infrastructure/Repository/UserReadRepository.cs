using DatabasesComplusory.Domain.Entities.Read;
using DatabasesComplusory.Domain.Interfaces;
using DatabasesComplusory.Infrastructure.Context;
using MongoDB.Driver;

public class UserReadRepository : IUserReadRepository
{
    private readonly MongoDbContext _context;

    public UserReadRepository(MongoDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<UserRead> GetByIdAsync(int userId)
    {
        return await _context.Users
                             .Find(u => u.UserId == userId)
                             .FirstOrDefaultAsync();
    }
}