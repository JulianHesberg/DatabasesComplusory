using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace DatabasesComplusory.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<IDbContextTransaction?> BeginTransactionAsync(IsolationLevel isolationLevel);
    Task CommitAsync();
    Task RollbackAsync();
    Task SaveChangesAsync();
}