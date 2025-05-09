using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using DatabasesComplusory.Domain.Interfaces;
using DatabasesComplusory.Infrastructure.Context;

namespace DatabasesComplusory.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EfCoreContext _context;
    private IDbContextTransaction? _transaction;
    
    public UnitOfWork(EfCoreContext context)
    {
        _context = context;
    }
    
    public async Task<IDbContextTransaction?> BeginTransactionAsync(IsolationLevel isolationLevel)
    {
        _transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
        return _transaction;
    }

    public async Task CommitAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }
        await _transaction.CommitAsync();
        await _transaction.DisposeAsync();
    }

    public async Task RollbackAsync()
    {
        if(_transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
    }
    
    public async Task SaveChangesAsync()
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("Transaction has not been started.");
        }
        await _context.SaveChangesAsync();
    }
}