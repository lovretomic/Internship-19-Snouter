using Snouter.Application.Models;

namespace Snouter.Application.Repositories;

public interface ISubcategoryRepository
{
    Task<bool> CreateAsync(Subcategory subcategory);
    Task<Subcategory> GetByNameAsync(string name);
    Task<IEnumerable<Subcategory>> GetAllAsync();
    Task<bool> DeleteByNameAsync(string name);
}