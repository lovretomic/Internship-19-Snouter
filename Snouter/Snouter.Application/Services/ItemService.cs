using FluentValidation;
using Snouter.Application.Models.Item;
using Snouter.Application.Repositories;
using Snouter.Application.Validators;

namespace Snouter.Application.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly ItemValidator _itemValidator;

    public ItemService(IItemRepository itemRepository, ItemValidator itemValidator)
    {
        _itemRepository = itemRepository;
        _itemValidator = itemValidator;
    }
    
    public async Task<bool> CreateAsync(Item item)
    {
        var result = await _itemValidator.ValidateAsync(item);
        if (!result.IsValid) return false;
        return await _itemRepository.CreateAsync(item);
    }

    public Task<Item> GetByIdAsync(Guid id)
    {
        return _itemRepository.GetByIdAsync(id);
    }

    public Task<bool> UpdateAsync(Item item)
    {
        return _itemRepository.UpdateAsync(item);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        return _itemRepository.DeleteByIdAsync(id);
    }
}