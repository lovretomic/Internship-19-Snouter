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
    
    public async Task<bool> CreateAsync(User user)
    {
        await _userValidator.ValidateAndThrowAsync(user);
        return await _userRepository.CreateAsync(user);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(User user)
    {
        return await _userRepository.UpdateAsync(user);
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        return await _userRepository.DeleteByIdAsync(id);
    }
}