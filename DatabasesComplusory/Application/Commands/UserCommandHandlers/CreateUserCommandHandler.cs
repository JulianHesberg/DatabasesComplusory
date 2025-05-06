using System.Data;
using DatabasesComplusory.Application.Commands.UserCommands;
using DatabasesComplusory.Application.Events;
using DatabasesComplusory.Application.Interfaces;
using DatabasesComplusory.Domain.Entities.Write;
using DatabasesComplusory.Domain.Interfaces;

namespace DatabasesComplusory.Application.Handlers.UserHandlers;

public class CreateUserCommandHandler
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventBus _eventBus;
    
    public CreateUserCommandHandler(IUserRepository repository, IEventBus eventBus, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _eventBus = eventBus;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CreateUserCommand command)
    {
        using var transaction = await _unitOfWork.BeginTransactionAsync(IsolationLevel.Serializable);
        try
        {
            var user = new User
            {
                Name = command.Name,
                Email = command.Email,
            };
            var created = await _repository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            var userCreatedEvent = new UserCreatedEvent
            {
                UserId = created.UserId,
                Name = created.Name,
                Email = created.Email
            };
            await _eventBus.Publish(userCreatedEvent);
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    
    
}