using DatabasesComplusory.Models.Write;

namespace DatabasesComplusory.Repository.Interfaces;

public interface IReviewRepository
{
    Task<Review> AddAsync(Review review);
    Task<Review> GetByIdAsync(int id);
    Task<List<Review>> GetAllAsync();
    Task UpdateAsync(Review review);
    Task DeleteAsync(int id);
}