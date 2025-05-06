using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Application.Service.Interfaces;

public interface IListingService
{
    Task<Listing> AddAsync(Listing listing);
    Task<Listing> GetByIdAsync(int id);
    Task<List<Listing>> GetAllAsync();
    Task UpdateAsync(Listing listing);
    Task DeleteAsync(int id);
}
