using Snouter.Application.Models;

namespace Snouter.Application.Services;

public interface ICategoryService
{
    Task<bool> CreateAsync(Category category);
    Task<Category> GetByNameAsync(string name);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<bool> DeleteByNameAsync(string name);
}