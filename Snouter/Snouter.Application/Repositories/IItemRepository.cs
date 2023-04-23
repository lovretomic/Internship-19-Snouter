using Snouter.Application.Models.Item;

namespace Snouter.Application.Repositories;

public interface IItemRepository
{
    Task<bool> CreateAsync(Item item);
    Task<Item> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Item item);
    Task<bool> DeleteByIdAsync(Guid id);
}