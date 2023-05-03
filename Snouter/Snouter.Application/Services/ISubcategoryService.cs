using Snouter.Application.Models;

namespace Snouter.Application.Services;

public interface ISubcategoryService
{
    Task<bool> CreateAsync(Subcategory subcategory, string categoryName, CancellationToken token = default);
    Task<Subcategory> GetByNameAsync(string name);
    Task<IEnumerable<Subcategory>> GetAllAsync(CancellationToken token = default);
    Task<bool> DeleteByNameAsync(string name, CancellationToken token = default);
}