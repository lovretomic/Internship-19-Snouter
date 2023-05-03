using Snouter.Application.Models.Item;

namespace Snouter.Application.Repositories;

public interface IItemRepository
{
    Task<bool> CreateAsync(Item item, CancellationToken token);
    Task<Item> GetByIdAsync(Guid id, CancellationToken token);
    Task<bool> UpdateAsync(Item item, CancellationToken token);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token);
}