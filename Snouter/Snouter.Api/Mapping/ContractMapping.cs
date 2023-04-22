using Snouter.Application.Models.User;
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
}