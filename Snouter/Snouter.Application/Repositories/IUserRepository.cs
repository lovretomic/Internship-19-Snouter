using Snouter.Application.Models.User;

namespace Snouter.Application.Repositories;

public interface IUserRepository
{
    Task<bool> CreateAsync(User user, CancellationToken token = default);
    Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<bool> UpdateAsync(User user, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}