using DatabasesComplusory.Models.Read;
using DatabasesComplusory.Service.Interfaces;

namespace DatabasesComplusory.Service;

public class ListingReadingService : IListingReadService
{
    public Task<List<ListingRead>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}