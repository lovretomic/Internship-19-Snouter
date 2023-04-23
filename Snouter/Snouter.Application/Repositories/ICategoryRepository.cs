using Snouter.Application.Models;

namespace Snouter.Application.Repositories;

public interface ICategoryRepository
{
    Task<bool> CreateAsync(Category category);
    Task<Category> GetByNameAsync(string name);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<bool> DeleteByNameAsync(string name);
}