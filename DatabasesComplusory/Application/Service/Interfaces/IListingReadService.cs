using DatabasesComplusory.Domain.Entities.Read;

namespace DatabasesComplusory.Application.Service.Interfaces;

public interface IListingReadService
{
    Task<List<ListingRead>> GetAllAsync();
}