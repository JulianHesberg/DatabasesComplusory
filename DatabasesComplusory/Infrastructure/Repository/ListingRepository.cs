using DatabasesComplusory.Domain.Entities.Write;
using DatabasesComplusory.Domain.Interfaces;
using DatabasesComplusory.Infrastructure.Context;

namespace DatabasesComplusory.Infrastructure.Repository;

public class ListingRepository : IListingRepository
{
    private readonly EfCoreContext _context;
    
    public ListingRepository(EfCoreContext context)
    {
        _context = context;
    }
    public async Task<Listing> AddAsync(Listing listing)
    {
        var entity = await _context.Listings.AddAsync(listing);
        return entity.Entity;
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
