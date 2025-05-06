using DatabasesComplusory.Application.Service.Interfaces;
using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Application.Service;

public class ListingService : IListingService
{
    public Task<Listing> AddAsync(Listing listing)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Listing>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Listing> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Listing listing)
    {
        throw new NotImplementedException();
    }
}