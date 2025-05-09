using DatabasesComplusory.Application.Domain.Entities.Read;

namespace DatabasesComplusory.Domain.Interfaces;

public interface IReviewReadRepository
{
    Task<List<ReviewRead>> GetAllAsync();
    Task<ReviewRead> GetByIdAsync(int reviewId);
    Task<List<ReviewRead>> GetBySellerIdAsync(int sellerId);
}