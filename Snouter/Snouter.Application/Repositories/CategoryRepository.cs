using Snouter.Application.Models;

namespace Snouter.Application.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private List<Category> _categories = new();
    
    public Task<bool> CreateAsync(Category category)
    {
        if (_categories.Contains(category))
        {
            return Task.FromResult(false);
        }
        _categories.Add(category);
        return Task.FromResult(true);
    }

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Category>>(_categories);
    }

    public Task<bool> UpdateAsync(Category category)
    {
        var existingCategory = _categories.SingleOrDefault(x => x.Name == category.Name);

        if (existingCategory is null)
        {
            return Task.FromResult(false);
        }

        existingCategory.Name = category.Name;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByName(string name)
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