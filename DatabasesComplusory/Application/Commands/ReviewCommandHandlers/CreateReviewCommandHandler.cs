using System.Data;
using DatabasesComplusory.Application.Commands.ReviewCommands;
using DatabasesComplusory.Application.Events.UserEvents;
using DatabasesComplusory.Application.Interfaces;
using DatabasesComplusory.Domain.Entities.Write;
using DatabasesComplusory.Domain.Interfaces;

namespace DatabasesComplusory.Application.Commands.ReviewCommandHandlers;

public class CreateReviewCommandHandler
{
    private readonly IReviewRepository _repo;
    private readonly IUnitOfWork _uow;
    private readonly IEventBus _bus;

    public CreateReviewCommandHandler(
        IReviewRepository repo,
        IUnitOfWork uow,
        IEventBus bus)
    {
        _repo = repo;
        _uow = uow;
        _bus = bus;
    }

    public async Task<Review> HandleAsync(CreateReviewCommand cmd)
    {
        using var tx = await _uow.BeginTransactionAsync(IsolationLevel.Serializable);
        try
        {
            var review = new Review
            {
                UserId = cmd.UserId,
                SellerId = cmd.SellerId,
                Rating = cmd.Rating,
                Comment = cmd.Comment
            };

            var created = await _repo.AddAsync(review);
            await _uow.SaveChangesAsync();

            var evt = new ReviewCreatedEvent
            {
                ReviewId = created.ReviewId,
                UserId = created.UserId,
                SellerId = created.SellerId,
                Rating = created.Rating,
                Comment = created.Comment
            };
            await _bus.Publish(evt);
            await _uow.CommitAsync();
            return created;
        }
        catch
        {
            await _uow.RollbackAsync();
            throw;
        }
    }
}