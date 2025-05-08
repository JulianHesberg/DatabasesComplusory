using DatabasesComplusory.Domain.Entities.Read;
using DatabasesComplusory.Domain.Interfaces;

namespace DatabasesComplusory.Infrastructure.Repository;

public class ListingReadRepository : IListingReadRepository
{
    public Task<List<ListingRead>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
