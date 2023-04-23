using Snouter.Application.Models;

namespace Snouter.Application.Repositories;

public interface ICategoryRepository
{
    Task<bool> CreateAsync(Category category);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteByName(string name);
}