using BusinessLayer.Domain.User;
using BusinessLayer.Interfaces.User;
using BusinessLayer.Services.Helper;
using FluentValidation;

namespace BusinessLayer.Services.User
{
    public class RegisterService(IValidator<Register> validator, IPasswordHasherService passwordHasherService) : IRegisterService
    {
        private readonly IValidator<Register> _validator = validator;
        private readonly IPasswordHasherService _passwordHasherService = passwordHasherService;

        public (bool Success, List<string> errors) RegisterUser(Register newUser)
        {
            var result = _validator.Validate(newUser);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return (false, errors);
            }


            string hashedPassword = _passwordHasherService.HashPassword(newUser.Password);
            newUser.Password = hashedPassword;


            return (true, new List<string>());
        }
    }
}
