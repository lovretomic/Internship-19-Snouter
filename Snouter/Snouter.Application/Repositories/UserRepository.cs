using Dapper;
using Snouter.Application.Database;
using Snouter.Application.Models.User;

namespace Snouter.Application.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public UserRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    
    public async Task<bool> CreateAsync(User user)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            insert into Users (Id, FullName, Email, Password, CreatedAt, ProfilePicUrl, Latitude, Longitude)
            values (@Id, @FullName, @Email, @Password, @CreatedAt, @ProfilePicUrl, @Latitude, @Longitude)
        ", user));

        if (result <= 0) return false;
        
        transaction.Commit();
        return result > 0;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        var result = await connection.QueryAsync(new CommandDefinition(@"
            select * from Users
        "));

        return result.Select(x => new User
        {
            Id = x.id,
            FullName = x.fullname,
            Email = x.email,
            Password = x.password,
            CreatedAt = x.createdat,
            ProfilePicUrl = x.profilepicurl,
            Latitude = x.latitude,
            Longitude= x.longitude
        });
    }
    
    public async Task<User?> GetByIdAsync(Guid id)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();

        var user = await connection.QuerySingleOrDefaultAsync<User>(new CommandDefinition(@"
            select * from Users where Id = @id
        ", new { id }));
        
        return user;
    }

    public async Task<bool> UpdateAsync(User user)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            update Users set FullName = @FullName,
                             Email = @Email,
                             Password = @Password,
                             CreatedAt = @CreatedAt,
                             ProfilePicUrl = @ProfilePicUrl,
                             Latitude = @Latitude,
                             Longitude = @Longitude
            where Id = @Id
        ", user));
        
        transaction.Commit();
        return result > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        using var transaction = connection.BeginTransaction();

        var result = await connection.ExecuteAsync(new CommandDefinition(@"
            delete from Users where Id = @id
        ", new { id }));
        
        transaction.Commit();
        return result > 0;
    }
}