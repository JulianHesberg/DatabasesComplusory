using DatabasesComplusory.Application.Service.Interfaces;
using DatabasesComplusory.Domain.Entities.Read;

namespace DatabasesComplusory.Application.Service;

public class ListingReadingService : IListingReadService
{
    public Task<List<ListingRead>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}