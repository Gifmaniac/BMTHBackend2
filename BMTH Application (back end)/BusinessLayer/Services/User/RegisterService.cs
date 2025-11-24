using BusinessLayer.Domain.User;
using BusinessLayer.Interfaces.Helper;
using BusinessLayer.Interfaces.User;
using BusinessLayer.Mapper.ApiMapper.Auth;
using BusinessLayer.Mapper.ApiMapper.StoreItems.User;
using BusinessLayer.Mapper.DALMapper.User;
using BusinessLayer.Services.Helper.User;
using Contracts.DTOs.Responses;
using Contracts.DTOs.User;
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

        public async Task<AuthResponseDto> RegisterUser(RegisterUserDto newUser)
        {
            var domainNewUser = RegisterUserApiMapper.ToDomain(newUser);

            // Validates the user input
            var result = _validator.Validate(domainNewUser);
            if (!result.IsValid)
            {
                return AuthResponseFactory.Fail(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // Checks if email already exists
            if (await _userRegisterRepository.DoesEmailExists(domainNewUser.Email))
            {
                return AuthResponseFactory.Fail("Email already exists");
            }

            // Sets users password, role and creation date
            domainNewUser.Password = _passwordHasherService.HashPassword(domainNewUser.Password);
            domainNewUser.Role = Roles.User;
            domainNewUser.CreatedAt = DateTime.UtcNow;

            // Maps and saves the user to the database
            var model = UserRegisterMapper.ToUserModel(domainNewUser);
            var registerTask = _userRegisterRepository.RegisterUserTask(model);

            // Successful registration
            return AuthResponseFactory.Success();
        }
    }
}
