using Snouter.Application.Models;

namespace Snouter.Application.Repositories;

public class SubcategoryRepository : ISubcategoryRepository
{
    private List<Subcategory> _subcategories = new();
    
    public Task<bool> CreateAsync(Subcategory subcategory)
    {
        var hasDuplicate = _subcategories.GroupBy(x => new { x.Name }).Any(g => g.Count() > 0);

        if (hasDuplicate)
        {
            return Task.FromResult(false);
        }
        _subcategories.Add(subcategory);
        
        return Task.FromResult(true);
    }

    public Task<Subcategory> GetByNameAsync(string name)
    {
        var subcategory = _subcategories.SingleOrDefault(x => x.Name == name);
        return Task.FromResult(subcategory);
    }

    public Task<IEnumerable<Subcategory>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Subcategory>>(_subcategories);
    }

    public Task<bool> DeleteByNameAsync(string name)
    {
        var existingCategory = _subcategories.SingleOrDefault(x => x.Name == name);

        if (existingCategory is null)
        {
            return Task.FromResult(false);
        }

        _subcategories.Remove(existingCategory);
        return Task.FromResult(true);
    }
}