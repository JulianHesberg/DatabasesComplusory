
using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Domain.Interfaces;

public interface IReviewRepository
{
    Task<Review> AddAsync(Review review);
    Task<Review> GetByIdAsync(int id);
    Task<List<Review>> GetAllAsync();
    Task UpdateAsync(Review review);
    Task DeleteAsync(int id);
}