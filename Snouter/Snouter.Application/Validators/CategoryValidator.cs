using FluentValidation;
using Snouter.Application.Models;

namespace Snouter.Application.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}