using Snouter.Application.Models.Item;

namespace Snouter.Application.Services;

public interface IItemService
{
    Task<bool> CreateAsync(Item item, CancellationToken token = default);
    Task<Item> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<bool> UpdateAsync(Item item, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}