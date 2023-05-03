using Dapper;

namespace Snouter.Application.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DbInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        await connection.ExecuteAsync(@"
            create table if not exists Users (
                Id UUID primary key,
                FullName TEXT,
                Email TEXT,
                Password TEXT,
                CreatedAt date not null,
                ProfilePicUrl TEXT,
                Latitude INTEGER,
                Longitude INTEGER
            );
        ");

        await connection.ExecuteAsync(@"
            create table if not exists Items (
                Id UUID,
                AuthorId UUID,
                Title TEXT,
                CreatedAt date,
                Subcategory TEXT,
                Description TEXT,
                ImageLinks TEXT,
                Price NUMERIC(15, 2),
                Currency TEXT,
                IsSold BOOLEAN,
                AdditionalProps TEXT
            );
        ");

        await connection.ExecuteAsync(@"
            create table if not exists Categories (
                Name TEXT UNIQUE NOT NULL
            );
        ");

        await connection.ExecuteAsync(@"
            create table if not exists Subcategories (
                Name TEXT,
                CategoryName TEXT,
                AdditionalProps TEXT
            );
        ");
    }
}