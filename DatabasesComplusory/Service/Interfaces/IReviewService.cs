using DatabasesComplusory.Models.Write;

namespace DatabasesComplusory.Service.Interfaces;

public interface IReviewService
{
    Task<Review> AddAsync(Review review);
    Task<Review> GetByIdAsync(int id);
    Task<List<Review>> GetAllAsync();
    Task UpdateAsync(Review review);
    Task DeleteAsync(int id);
}