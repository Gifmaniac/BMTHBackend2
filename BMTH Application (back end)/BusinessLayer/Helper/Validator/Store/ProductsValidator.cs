using BusinessLayer.Domain.Store.Products;
using FluentValidation;


namespace BusinessLayer.Helper.Validator.Store
{
    public class ProductsValidator : AbstractValidator<Products>
    {
        public ProductsValidator()
        {
            RuleFor(x => x.Gender)
                .IsInEnum()
                .WithMessage("Gender must be valid.");

            RuleFor(x => x.Material)
                .NotEmpty().WithMessage("Material is required.")
                .MaximumLength(100).WithMessage("Material cannot exceed 100 characters.");

            RuleFor(x => x.Variants)
                .NotEmpty().WithMessage("At least one variant must be provided.")
                .Must(v => v
                    .GroupBy(pv => new { pv.Color, pv.Size })
                    .All(g => g.Count() == 1))
                .WithMessage("Duplicate variant combinations (Color + Size) are not allowed.");

            RuleForEach(x => x.Variants)
                .SetValidator(new ProductsVariantsValidator());
        }
    }
}
