using Snouter.Application.Models;
using Snouter.Application.Models.Item;
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
            Lat = user.Lat,
            Long = user.Long
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
            Lat = request.Lat,
            Long = request.Long,
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
            Lat = request.Lat,
            Long = request.Long,
            Password = request.Password,
            ProfilePicUrl = request.ProfilePicUrl
        };
    }

    public static Category MapToCategory(this CreateCategoryRequest request)
    {
        return new Category()
        {
            Name = request.Name
        };
    }

    public static CategoryResponse MapToResponse(this Category category)
    {
        return new CategoryResponse
        {
            Name = category.Name
        };
    }

    public static Subcategory MapToSubcategory(this CreateSubcategoryRequest subcategory, string categoryName)
    {
        return new Subcategory
        {
            Name = subcategory.Name,
            CategoryName = categoryName,
            AdditionalProps = subcategory.AdditionalProps
        };
    }

    public static ItemResponse MapToResponse(this Item item)
    {
        return new ItemResponse()
        {
            AdditionalProps = item.AdditionalProps,
            AuthorId = item.AuthorId,
            Subcategory = item.Subcategory,
            CreatedAt = item.CreatedAt,
            Currency = item.Currency,
            Description = item.Description,
            Id = item.Id,
            ImageLinks = item.ImageLinks,
            Price = item.Price,
            Title = item.Title
        };
    }

    public static Item MapToItem(this CreateItemRequest request)
    {
        return new Item
        {
            AdditionalProps = request.AdditionalProps,
            AuthorId = request.AuthorId,
            Subcategory = request.Subcategory,
            CreatedAt = request.CreatedAt,
            Currency = request.Currency,
            Description = request.Description,
            Id = Guid.NewGuid(),
            ImageLinks = request.ImageLinks,
            Price = request.Price,
            Title = request.Title
        };
    }

    public static Item MapToTask(this UpdateItemRequest request, Guid id)
    {
        return new Item
        {
            AdditionalProps = request.AdditionalProps,
            AuthorId = request.AuthorId,
            Subcategory = request.Subcategory,
            CreatedAt = request.CreatedAt,
            Currency = request.Currency,
            Description = request.Description,
            Id = id,
            ImageLinks = request.ImageLinks,
            Price = request.Price,
            Title = request.Title
        };
    }
}