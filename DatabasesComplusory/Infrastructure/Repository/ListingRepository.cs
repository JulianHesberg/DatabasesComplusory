using DatabasesComplusory.Domain.Entities.Write;
using DatabasesComplusory.Domain.Interfaces;

namespace DatabasesComplusory.Infrastructure.Repository;

public class ListingRepository : IListingRepository
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
