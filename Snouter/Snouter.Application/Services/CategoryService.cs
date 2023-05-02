using FluentValidation;
using Snouter.Application.Models;
using Snouter.Application.Repositories;
using Snouter.Application.Validators;

namespace Snouter.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryValidator _categoryValidator;
    
    public CategoryService(ICategoryRepository categoryRepository, CategoryValidator categoryValidator)
    {
        _categoryRepository = categoryRepository;
        _categoryValidator = categoryValidator;
    }
    
    public async Task<bool> CreateAsync(Category category)
    {
        await _categoryValidator.ValidateAndThrowAsync(category);
        return await _categoryRepository.CreateAsync(category);
    }

    public async Task<Category> GetByNameAsync(string name)
    {
        return await _categoryRepository.GetByNameAsync(name);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<bool> DeleteByNameAsync(string name)
    {
        return await _categoryRepository.DeleteByNameAsync(name);
    }
}