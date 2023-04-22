using Snouter.Application.Models.User;

namespace Snouter.Application.Repositories;

public class UserRepository : IUserRepository
{
    private List<User> _users = new();
    
    public Task<bool> CreateAsync(User user)
    {
        if (_users.Contains(user))
        {
            return Task.FromResult(false);
        }
        _users.Add(user);
        return Task.FromResult(true);
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        var user = _users.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(user);
    }

    public Task<bool> UpdateAsync(User user)
    {
        var existingUser = _users.SingleOrDefault(x => x.Id == user.Id);

        if (existingUser is null)
        {
            return Task.FromResult(false);
        }

        existingUser.FullName = user.FullName;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.Location = user.Location;
        existingUser.ProfilePicUrl = user.ProfilePicUrl;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var existingUser = _users.SingleOrDefault(x => x.Id == id);

        if (existingUser is null)
        {
            return Task.FromResult(false);
        }

        _users.Remove(existingUser);
        return Task.FromResult(true);
    }
}