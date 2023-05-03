using Dapper;
using Snouter.Application.Database;
using Snouter.Application.Models;

namespace Snouter.Application.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    
    public CategoryRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    
    public async Task<bool> CreateAsync(Category category, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            INSERT INTO Categories (Name)
            VALUES (@Name)
            ON CONFLICT DO NOTHING;
        ", category, cancellationToken: token));

        if (result <= 0) return false;
        
        transaction.Commit();
        return result > 0;
    }
    public async Task<Category> GetByNameAsync(string name)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        var category = await connection.QuerySingleOrDefaultAsync<Category>(new CommandDefinition(@"
            select * from Categories where Name = @Name
        ", new { Name = name }));

        return category;
    }
    
    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        var result = await connection.QueryAsync(new CommandDefinition(@"
            select * from Categories
        ", cancellationToken: token));

        return result.Select(x => new Category
        {
            Name = x.name
        });
    }
    
    public async Task<bool> DeleteByNameAsync(string name, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            delete from Categories where Name = @Name
        ", new { Name = name }, cancellationToken: token));
        
        transaction.Commit();
        return result > 0;
    }
}