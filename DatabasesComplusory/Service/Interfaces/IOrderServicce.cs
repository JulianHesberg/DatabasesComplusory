using DatabasesComplusory.Models.Write;

namespace DatabasesComplusory.Service.Interfaces;

public interface IOrderService
{
    Task<Order> AddAsync(Order order);
    Task<Order> GetByIdAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);
}