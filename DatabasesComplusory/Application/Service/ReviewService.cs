using DatabasesComplusory.Application.Service.Interfaces;
using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Application.Service;

public class ReviewService : IReviewService
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