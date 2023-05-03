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
    
    public async Task<bool> CreateAsync(Category category, CancellationToken token = default)
    {
        await _categoryValidator.ValidateAndThrowAsync(category, cancellationToken: token);
        return await _categoryRepository.CreateAsync(category, token);
    }

    public async Task<Category> GetByNameAsync(string name)
    {
        return await _categoryRepository.GetByNameAsync(name);
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken token = default)
    {
        return await _categoryRepository.GetAllAsync(token);
    }

    public async Task<bool> DeleteByNameAsync(string name, CancellationToken token = default)
    {
        return await _categoryRepository.DeleteByNameAsync(name, token);
    }
}