using FluentValidation;
using Snouter.Application.Models;
using Snouter.Application.Repositories;
using Snouter.Application.Validators;

namespace Snouter.Application.Services;

public class SubcategoryService : ISubcategoryService
{
    private readonly ISubcategoryRepository _subcategoryRepository;
    private readonly SubcategoryValidator _subcategoryValidator;
    
    public SubcategoryService(ISubcategoryRepository subcategoryRepository, SubcategoryValidator subcategoryValidator)
    {
        _subcategoryRepository = subcategoryRepository;
        _subcategoryValidator = subcategoryValidator;
    }
    
    public async Task<bool> CreateAsync(Subcategory subcategory, string categoryName, CancellationToken token = default)
    {
        await _subcategoryValidator.ValidateAndThrowAsync(subcategory, cancellationToken: token);
        return await _subcategoryRepository.CreateAsync(subcategory, categoryName, token);
    }

    public async Task<Subcategory> GetByNameAsync(string name)
    {
        return await _subcategoryRepository.GetByNameAsync(name);
    }

    public async Task<IEnumerable<Subcategory>> GetAllAsync(CancellationToken token = default)
    {
        return await _subcategoryRepository.GetAllAsync(token);
    }

    public async Task<bool> DeleteByNameAsync(string name, CancellationToken token = default)
    {
        return await _subcategoryRepository.DeleteByNameAsync(name, token);
    }
}