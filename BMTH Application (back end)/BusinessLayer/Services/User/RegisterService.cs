using BusinessLayer.Domain.User;
using BusinessLayer.Interfaces.User;
using BusinessLayer.Mapper.DALMapper.User;
using BusinessLayer.Services.Helper;
using Contracts.Enums.User;
using DataLayer.Interfaces.User;
using FluentValidation;

namespace BusinessLayer.Services.User
{
    public class RegisterService(IValidator<Register> validator, IPasswordHasherService passwordHasherService, IUserRegisterRepository userRegisterRepository) : IRegisterService
    {
        private readonly IValidator<Register> _validator = validator;
        private readonly IPasswordHasherService _passwordHasherService = passwordHasherService;
        private readonly IUserRegisterRepository _userRegisterRepository = userRegisterRepository;

        public async Task<(bool Success, List<string> Errors)> RegisterUser(Register newUser)
        {
            // Validates the user input
            var result = _validator.Validate(newUser);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return (false, errors);
            }

            // Checks if email already exists
            if (await _userRegisterRepository.DoesEmailExists(newUser.Email))
            {
                return (false, new List<string> { "Email already exists" });
            }

            // Sets users password, role and creation date
            newUser.Password = _passwordHasherService.HashPassword(newUser.Password);
            newUser.Role = Roles.User;
            newUser.CreatedAt = DateTime.UtcNow;

            // Maps and saves the user to the database
            var model = UserRegisterMapper.ToModel(newUser);
            var registerTask = _userRegisterRepository.RegisterUserTask(model);

            // Successful registration
            return (true, new List<string>());
        }
    }
}
