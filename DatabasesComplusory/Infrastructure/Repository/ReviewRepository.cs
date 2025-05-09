using DatabasesComplusory.Domain.Entities.Write;
using DatabasesComplusory.Domain.Interfaces;
using DatabasesComplusory.Infrastructure.Context;

namespace DatabasesComplusory.Infrastructure.Repository;

public class ReviewRepository : IReviewRepository
{

    private readonly EfCoreContext _db;

    public ReviewRepository(EfCoreContext db)
    {
        _db = db;
    }
    
    public async Task<Review> AddAsync(Review review)
    {
        var entry = await _db.Reviews.AddAsync(review);
        return entry.Entity;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Review>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Review> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Review review)
    {
        throw new NotImplementedException();
    }
}