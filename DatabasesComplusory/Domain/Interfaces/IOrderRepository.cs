using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order> AddAsync(Order order);
    Task<Order> GetByIdAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);
}