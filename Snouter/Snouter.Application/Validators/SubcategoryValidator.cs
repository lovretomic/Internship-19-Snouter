using FluentValidation;
using Snouter.Application.Models;

namespace Snouter.Application.Validators;

public class SubcategoryValidator : AbstractValidator<Subcategory>
{
    public SubcategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.CategoryName).NotEmpty();
        RuleFor(x => x.AdditionalProps).NotEmpty();
    }
}