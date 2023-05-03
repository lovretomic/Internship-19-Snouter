using FluentValidation;
using Snouter.Application.Models.User;
using Snouter.Application.Repositories;
using Snouter.Application.Validators;

namespace Snouter.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserValidator _userValidator;

    public UserService(IUserRepository userRepository, UserValidator userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }
    
    public async Task<bool> CreateAsync(User user, CancellationToken token = default)
    {
        await _userValidator.ValidateAndThrowAsync(user, cancellationToken: token);
        return await _userRepository.CreateAsync(user, token);
    }

    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken token = default)
    {
        return await _userRepository.GetAllAsync(token);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _userRepository.GetByIdAsync(id, token);
    }

    public async Task<bool> UpdateAsync(User user, CancellationToken token = default)
    {
        return await _userRepository.UpdateAsync(user, token);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _userRepository.DeleteByIdAsync(id, token);
    }
}