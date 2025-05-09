using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Application.Service.Interfaces;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<User> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
}