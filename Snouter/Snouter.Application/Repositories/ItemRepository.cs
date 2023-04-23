using Snouter.Application.Models.Item;

namespace Snouter.Application.Repositories;

public class ItemRepository : IItemRepository
{
    private List<Item> _items = new();
    
    public Task<bool> CreateAsync(Item item)
    {
        if (_items.Contains(item))
        {
            return Task.FromResult(false);
        }
        _items.Add(item);
        return Task.FromResult(true);
    }

    public Task<Item> GetByIdAsync(Guid id)
    {
        var item = _items.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(item);
    }

    public Task<bool> UpdateAsync(Item item)
    {
        var existingItem = _items.SingleOrDefault(x => x.Id == item.Id);

        if (existingItem is null)
        {
            return Task.FromResult(false);
        }
        
        existingItem.Subcategory = item.Subcategory;
        existingItem.Currency = item.Currency;
        existingItem.CreatedAt = item.CreatedAt;
        existingItem.Title = item.Title;
        existingItem.Description = item.Description;
        existingItem.Price = item.Price;
        existingItem.AdditionalProps = item.AdditionalProps;
        existingItem.AuthorId = item.AuthorId;
        existingItem.ImageLinks = item.ImageLinks;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var existingItem = _items.SingleOrDefault(x => x.Id == id);

        if (existingItem is null)
        {
            return Task.FromResult(false);
        }

        _items.Remove(existingItem);
        return Task.FromResult(true);
    }
}