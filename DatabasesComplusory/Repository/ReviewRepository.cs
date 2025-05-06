using DatabasesComplusory.Models.Write;
using DatabasesComplusory.Repository.Interfaces;

namespace DatabasesComplusory.Repository;

public class ReviewRepository : IReviewRepository
{
    public Task<Review> AddAsync(Review review)
    {
        throw new NotImplementedException();
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