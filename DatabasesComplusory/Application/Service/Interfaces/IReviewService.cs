using DatabasesComplusory.Domain.Entities.Write;

namespace DatabasesComplusory.Application.Service.Interfaces;

public interface IReviewService
{
    Task<Review> AddAsync(Review review);
    Task<Review> GetByIdAsync(int id);
    Task<List<Review>> GetAllAsync();
    Task UpdateAsync(Review review);
    Task DeleteAsync(int id);
}