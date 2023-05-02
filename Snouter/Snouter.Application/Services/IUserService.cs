using Snouter.Application.Models.User;

namespace Snouter.Application.Services;

public interface IUserService
{
    Task<bool> CreateAsync(User user);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteByIdAsync(Guid id);
}