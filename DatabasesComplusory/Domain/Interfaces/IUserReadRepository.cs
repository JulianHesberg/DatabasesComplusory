using DatabasesComplusory.Domain.Entities.Read;


namespace DatabasesComplusory.Domain.Interfaces;
public interface IUserReadRepository
{
    Task<UserRead> GetByIdAsync(int userId);
}