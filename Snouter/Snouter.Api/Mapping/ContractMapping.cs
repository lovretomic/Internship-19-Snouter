using Snouter.Application.Models.User;
using Snouter.Contracts.Requests;
using Snouter.Contracts.Responses;

namespace Snouter.Api.Mapping;

public static class ContractMapping
{
    public static UserResponse MapToResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            Password = user.Password,
            CreatedAt = user.CreatedAt,
            ProfilePicUrl = user.ProfilePicUrl,
            Location = user.Location
        };
    }

    public static User MapToUser(this CreateUserRequest request)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            CreatedAt = request.CreatedAt,
            Email = request.Email,
            FullName = request.FullName,
            Location = request.Location,
            Password = request.Password,
            ProfilePicUrl = request.ProfilePicUrl
        };
    }
    
    public static User MapToUser(this UpdateUserRequest request, Guid id)
    {
        return new User
        {
            Id = id,
            CreatedAt = request.CreatedAt,
            Email = request.Email,
            FullName = request.FullName,
            Location = request.Location,
            Password = request.Password,
            ProfilePicUrl = request.ProfilePicUrl
        };
    }
}