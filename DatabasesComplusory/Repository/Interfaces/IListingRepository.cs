using DatabasesComplusory.Models.Write;

namespace DatabasesComplusory.Repository.Interfaces;

public interface IListingRepository
{
    Task<Listing> AddAsync(Listing listing);
    Task<Listing> GetByIdAsync(int id);
    Task<List<Listing>> GetAllAsync();
    Task UpdateAsync(Listing listing);
    Task DeleteAsync(int id);
}