namespace DatabasesComplusory.Repository;

using DatabasesComplusory.Models.Read;
using DatabasesComplusory.Repository.Interfaces;

public class ListingReadRepository : IListingReadRepository
{
    public Task AddAsync(ListingRead listingRead)
    {
        throw new NotImplementedException();
    }

    public Task<List<ListingRead>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
