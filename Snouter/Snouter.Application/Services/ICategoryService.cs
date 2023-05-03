using Snouter.Application.Models;

namespace Snouter.Application.Services;

public interface ICategoryService
{
    Task<bool> CreateAsync(Category category, CancellationToken token = default);
    Task<Category> GetByNameAsync(string name);
    Task<IEnumerable<Category>> GetAllAsync(CancellationToken token = default);
    Task<bool> DeleteByNameAsync(string name, CancellationToken token = default);
}