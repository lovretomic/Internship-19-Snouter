using Snouter.Application.Models;

namespace Snouter.Application.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private List<Category> _categories = new();
    
    public Task<bool> CreateAsync(Category category)
    {
        var hasDuplicate = _categories.GroupBy(x => new { x.Name }).Any(g => g.Count() > 0);

        if (hasDuplicate)
        {
            return Task.FromResult(false);
        }
        _categories.Add(category);
        
        return Task.FromResult(true);
    }
    public Task<Category> GetByNameAsync(string name)
    {
        var category = _categories.SingleOrDefault(x => x.Name == name);
        return Task.FromResult(category);
    }
    
    public Task<IEnumerable<Category>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Category>>(_categories);
    }
    
    public Task<bool> DeleteByNameAsync(string name)
    {
        var existingCategory = _categories.SingleOrDefault(x => x.Name == name);

        if (existingCategory is null)
        {
            return Task.FromResult(false);
        }

        _categories.Remove(existingCategory);
        return Task.FromResult(true);
    }
}