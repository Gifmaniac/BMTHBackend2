using FluentValidation;
using Contracts.DTOs.User;

namespace BusinessLayer.Helper.Validator.User
{
    public class LoginValidator : AbstractValidator<LoginUserDto>
    {
        public LoginValidator()
        {
            // Email validation
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Please enter a valid email address");

            // Password validation
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Please give a valid password")
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
