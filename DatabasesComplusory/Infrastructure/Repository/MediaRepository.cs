using DatabasesComplusory.Domain.Entities.Write;
using DatabasesComplusory.Domain.Interfaces;
using DatabasesComplusory.Infrastructure.Context;

namespace DatabasesComplusory.Infrastructure.Repository;

public class MediaRepository : IMediaRepository
{
    private readonly EfCoreContext _context;
    
    public MediaRepository(EfCoreContext context)
    {
        _context = context;
    }
    
    public async Task<Media> AddAsync(Media media)
    {
        var result = await _context.Media.AddAsync(media);
        return result.Entity;
    }

    public Task<IEnumerable<Media>> GetByListingIdAsync(int listingId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAllByListingIdAsync(int listingId)
    {
        throw new NotImplementedException();
    }
}