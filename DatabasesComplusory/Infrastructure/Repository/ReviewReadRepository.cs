using DatabasesComplusory.Application.Domain.Entities.Read;
using DatabasesComplusory.Domain.Interfaces;
using DatabasesComplusory.Infrastructure.Context;
using MongoDB.Driver;

namespace DatabasesComplusory.Infrastructure.Repository;

public class ReviewReadRepository : IReviewReadRepository
{
    private readonly MongoDbContext _context;
    public ReviewReadRepository(MongoDbContext mongo) => _context = mongo;


    public Task<List<ReviewRead>> GetAllAsync() =>
        _context.Reviews.Find(_ => true).ToListAsync();

    public Task<ReviewRead> GetByIdAsync(int id) =>
        _context.Reviews.Find(r => r.ReviewId == id).FirstOrDefaultAsync();


    public Task<List<ReviewRead>> GetBySellerIdAsync(int sellerId) => _context.Reviews
              .Find(r => r.SellerId == sellerId)
              .ToListAsync();
}