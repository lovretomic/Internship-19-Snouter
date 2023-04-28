using Dapper;
using Snouter.Application.Database;
using Snouter.Application.Models.Item;

namespace Snouter.Application.Repositories;

public class ItemRepository : IItemRepository
{
    private List<Item> _items = new();
    
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public ItemRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    public async Task<bool> CreateAsync(Item item)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            INSERT INTO Items (Id, AuthorId, Title, CreatedAt, Subcategory, Description,
                               ImageLinks, Price, Currency, AdditionalProps)
            VALUES (@Id, @AuthorId, @Title, @CreatedAt, @Subcategory, @Description, @ImageLinks,
                    @Price, @Currency, @AdditionalProps)
            ON CONFLICT DO NOTHING;
        ", item));

        if (result <= 0) return false;
        
        transaction.Commit();
        return result > 0;
        /*
        if (_items.Contains(item))
        {
            return Task.FromResult(false);
        }
        _items.Add(item);
        return Task.FromResult(true);
        */
    }

    public async Task<Item> GetByIdAsync(Guid id)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        var item = await connection.QuerySingleOrDefaultAsync<Item>(new CommandDefinition(@"
            select * from Items where Id = @Id
        ", new { Id = id }));

        return item;
        /*
        var item = _items.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(item);
        */
    }

    public async Task<bool> UpdateAsync(Item item)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            update Items set AuthorId = @AuthorId,
                             Title = @Title,
                             CreatedAt = @CreatedAt,
                             Subcategory = @Subcategory,
                             Description = @Description,
                             ImageLinks = @ImageLinks,
                             Price = @Price,
                             Currency = @Currency,
                             AdditionalProps = @AdditionalProps
            where Id = @Id
        ", item));
        
        transaction.Commit();
        return result > 0;
        /*
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
        */
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            delete from Items where Id = @id
        ", new { id }));
        
        transaction.Commit();
        return result > 0;
        /*
        var existingItem = _items.SingleOrDefault(x => x.Id == id);

        if (existingItem is null)
        {
            return Task.FromResult(false);
        }

        _items.Remove(existingItem);
        return Task.FromResult(true);
        */
    }
}