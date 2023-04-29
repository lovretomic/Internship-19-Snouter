﻿using Dapper;
using Snouter.Application.Database;
using Snouter.Application.Models.Item;

namespace Snouter.Application.Repositories;

public class ItemRepository : IItemRepository
{
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
    }

    public async Task<Item> GetByIdAsync(Guid id)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        var item = await connection.QuerySingleOrDefaultAsync<Item>(new CommandDefinition(@"
            select * from Items where Id = @Id
        ", new { Id = id }));

        return item;
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
    }
}