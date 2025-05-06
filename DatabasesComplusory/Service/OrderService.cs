using DatabasesComplusory.Models.Write;
using DatabasesComplusory.Service.Interfaces;

namespace DatabasesComplusory.Service;

public class OrderService : IOrderService
{
    public Task<Order> AddAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Order order)
    {
        throw new NotImplementedException();
    }
}