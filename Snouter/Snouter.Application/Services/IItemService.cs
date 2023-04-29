using Snouter.Application.Models.Item;

namespace Snouter.Application.Services;

public interface IItemService
{
    Task<bool> CreateAsync(Item item);
    Task<Item> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Item item);
    Task<bool> DeleteByIdAsync(Guid id);
}