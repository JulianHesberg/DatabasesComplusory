using DatabasesComplusory.Models.Write;
using DatabasesComplusory.Repository.Interfaces;

namespace DatabasesComplusory.Repository;

public class UserRepository : IUserRepository
{
    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
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
