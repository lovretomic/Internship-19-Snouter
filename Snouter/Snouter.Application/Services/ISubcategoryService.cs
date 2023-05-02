using Snouter.Application.Models;

namespace Snouter.Application.Services;

public interface ISubcategoryService
{
    Task<bool> CreateAsync(Subcategory subcategory, string categoryName);
    Task<Subcategory> GetByNameAsync(string name);
    Task<IEnumerable<Subcategory>> GetAllAsync();
    Task<bool> DeleteByNameAsync(string name);
}