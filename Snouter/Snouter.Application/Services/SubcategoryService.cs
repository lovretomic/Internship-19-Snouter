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
    
    public async Task<bool> CreateAsync(Subcategory subcategory, string categoryName)
    {
        await _subcategoryValidator.ValidateAndThrowAsync(subcategory);
        return await _subcategoryRepository.CreateAsync(subcategory, categoryName);
    }

    public async Task<Subcategory> GetByNameAsync(string name)
    {
        return await _subcategoryRepository.GetByNameAsync(name);
    }

    public async Task<IEnumerable<Subcategory>> GetAllAsync()
    {
        return await _subcategoryRepository.GetAllAsync();
    }

    public async Task<bool> DeleteByNameAsync(string name)
    {
        return await _subcategoryRepository.DeleteByNameAsync(name);
    }
}