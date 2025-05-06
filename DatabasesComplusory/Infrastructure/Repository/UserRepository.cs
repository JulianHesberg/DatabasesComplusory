using DatabasesComplusory.Domain.Entities.Write;
using DatabasesComplusory.Domain.Interfaces;
using DatabasesComplusory.Infrastructure.Context;

namespace DatabasesComplusory.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly EfCoreContext _context;
    public UserRepository(EfCoreContext context)
    {
        _context = context;
    }
    public async Task<User> AddAsync(User user)
    {
        var entity = await _context.Users.AddAsync(user);
        return entity.Entity;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
