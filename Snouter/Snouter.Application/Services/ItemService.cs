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
    
    public async Task<bool> CreateAsync(Item item, CancellationToken token = default)
    {
        await _itemValidator.ValidateAndThrowAsync(item, cancellationToken: token);

        return await _itemRepository.CreateAsync(item, token);
    }

    public Task<Item> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _itemRepository.GetByIdAsync(id, token);
    }

    public Task<bool> UpdateAsync(Item item, CancellationToken token)
    {
        return _itemRepository.UpdateAsync(item, token);
    }

    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return _itemRepository.DeleteByIdAsync(id, token);
    }
}