using DatabasesComplusory.Domain.Entities.Read;

namespace DatabasesComplusory.Domain.Interfaces;


public interface IListingReadRepository
{
    Task<List<ListingRead>> GetAllAsync();
}