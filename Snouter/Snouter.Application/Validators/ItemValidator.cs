using FluentValidation;
using Snouter.Application.Models.Item;

namespace Snouter.Application.Validators;

public class ItemValidator : AbstractValidator<Item>
{

    public ItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.AuthorId)
            .NotEmpty();

        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.CreatedAt)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.Subcategory)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.ImageLinks)
            .NotEmpty();

        RuleFor(x => x.Price)
            .NotEmpty();

        RuleFor(x => x.Currency)
            .NotEmpty();
    }
}