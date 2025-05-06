using DatabasesComplusory.Application.Service.Interfaces;
using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Application.Service;

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