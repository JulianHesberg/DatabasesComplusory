using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Domain.Interfaces;

public interface IMediaRepository
{
    Task<Media> AddAsync(Media media);
    Task<IEnumerable<Media>> GetByListingIdAsync(int listingId);
    Task DeleteAllByListingIdAsync(int listingId);
}