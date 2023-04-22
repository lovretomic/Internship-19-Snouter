using Snouter.Application.Models.User;

namespace Snouter.Application.Repositories;

public interface IUserRepository
{
    Task<bool> CreateAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteByIdAsync(Guid id);
}