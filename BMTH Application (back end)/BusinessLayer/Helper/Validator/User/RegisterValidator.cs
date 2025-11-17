using BusinessLayer.Domain.User;
using Contracts.Enums.User;
using FluentValidation;

namespace BusinessLayer.Helper.Validator.User
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            // Email validation
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Please enter a valid email address");

            // Password validation
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Please give a valid password")
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one symbol");

            // RoleValidation
            RuleFor(x => x.Role)
                .NotEqual(Roles.Guest)
                .NotEqual(Roles.Admin);

            // FirstName validation
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required");

            // LastName validation
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required");

        }
    }
}
