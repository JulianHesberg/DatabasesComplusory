using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int userId);
    Task<List<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}