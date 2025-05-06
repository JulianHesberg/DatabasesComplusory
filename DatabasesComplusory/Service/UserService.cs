using DatabasesComplusory.Models.Write;
using DatabasesComplusory.Service.Interfaces;

namespace DatabasesComplusory.Service;

public class UserService : IUserService
{
    public Task<User> AddAsync(User user)
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

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}