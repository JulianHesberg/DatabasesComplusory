using DatabasesComplusory.Models.Write;

namespace DatabasesComplusory.Service.Interfaces;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<User> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}