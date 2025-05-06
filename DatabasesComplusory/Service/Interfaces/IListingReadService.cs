using DatabasesComplusory.Models.Read;

namespace DatabasesComplusory.Service.Interfaces;

public interface IListingReadService
{
    Task<List<ListingRead>> GetAllAsync();
}