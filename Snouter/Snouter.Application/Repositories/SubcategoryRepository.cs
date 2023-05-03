using Dapper;
using Snouter.Application.Database;
using Snouter.Application.Models;

namespace Snouter.Application.Repositories;

public class SubcategoryRepository : ISubcategoryRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public SubcategoryRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    
    public async Task<bool> CreateAsync(Subcategory subcategory, string categoryName, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            INSERT INTO Subcategories (Name, CategoryName, AdditionalProps)
            VALUES (@Name, @CategoryName, @AdditionalProps)
            ON CONFLICT DO NOTHING;
        ", new { Name = subcategory.Name, AdditionalProps = subcategory.AdditionalProps, CategoryName = categoryName }, cancellationToken: token));

        if (result <= 0) return false;
        
        transaction.Commit();
        return result > 0;
    }

    public async Task<Subcategory> GetByNameAsync(string name)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        var subcategory = await connection.QuerySingleOrDefaultAsync<Subcategory>(new CommandDefinition(@"
            select * from Subcategories where Name = @Name
        ", new { Name = name }));

        return subcategory;
    }

    public async Task<IEnumerable<Subcategory>> GetAllAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        var result = await connection.QueryAsync(new CommandDefinition(@"
            select * from Subcategories
        ", cancellationToken: token));

        return result.Select(x => new Subcategory
        {
            Name = x.name,
            CategoryName = x.CategoryName,
            AdditionalProps = x.AdditionalProps
        });
    }

    public async Task<bool> DeleteByNameAsync(string name, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            delete from Subcategories where Name = @Name
        ", new { Name = name }, cancellationToken: token));
        
        transaction.Commit();
        return result > 0;
    }
}