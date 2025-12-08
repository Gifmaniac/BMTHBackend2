using FluentValidation;
using BusinessLayer.Domain.Store.Products;

namespace BusinessLayer.Helper.Validator.Store
{
    public class ProductsVariantsValidator : AbstractValidator<ProductsVariants>
    {
        public ProductsVariantsValidator()
        {
            RuleFor(x => x.VariantId)
                .GreaterThan(0).WithMessage("VariantId must be greater than 0.");

            RuleFor(x => x.ProductModelId)
                .GreaterThan(0).WithMessage("ProductModelId must be a valid ID.");

            RuleFor(x => x.Color)
                .IsInEnum()
                .WithMessage("Color must be a valid enum value.");

            RuleFor(x => x.Size)
                .IsInEnum()
                .WithMessage("Size must be a valid enum value.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantity cannot be negative.");
        }
    }
}