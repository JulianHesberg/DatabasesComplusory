using DatabasesComplusory.Domain.Entities.Write;
using DatabasesComplusory.Domain.Interfaces;

namespace DatabasesComplusory.Infrastructure.Repository;

public class OrderRepository : IOrderRepository
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
