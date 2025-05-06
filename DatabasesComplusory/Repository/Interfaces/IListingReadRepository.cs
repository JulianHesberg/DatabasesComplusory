namespace DatabasesComplusory.Repository.Interfaces;

using DatabasesComplusory.Models.Read;

public interface IListingReadRepository
{
    Task<List<ListingRead>> GetAllAsync();
}