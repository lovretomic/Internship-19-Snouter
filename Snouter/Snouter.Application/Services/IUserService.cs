using Snouter.Application.Models.User;

namespace Snouter.Application.Services;

public interface IUserService
{
    Task<bool> CreateAsync(User user, CancellationToken token = default);
    Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<bool> UpdateAsync(User user, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}