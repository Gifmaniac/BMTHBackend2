using BusinessLayer.Domain.User;
using BusinessLayer.Interfaces.Helper;
using BusinessLayer.Interfaces.User;
using BusinessLayer.Mapper.ApiMapper.StoreItems.User;
using BusinessLayer.Mapper.DALMapper.User;
using BusinessLayer.Services.Helper.User;
using Contracts.DTOs.Responses;
using Contracts.DTOs.User;
using Contracts.Enums.User;
using DataLayer.Interfaces.User;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Services.User
{
    public class LoginService(IValidator<LoginUserDto> validator, IPasswordHasherService passwordHasherService, IUserLoginRepository loginRepository) : ILoginService
    {
        private readonly IPasswordHasherService _hasher = passwordHasherService;
        private readonly IValidator<LoginUserDto> _validator = validator;
        private readonly IUserLoginRepository _loginRepository = loginRepository;

        public async Task<AuthResponseDto> LoginUser(LoginUserDto givenUserDto)
        {
            // Validates the user input if correct
            var result = _validator.Validate(givenUserDto);
            if (!result.IsValid)
            {
                return AuthResponseFactory.Fail(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // Checks if account exist and the password matches
            var domainNewUser = LoginUserApiMapper.toDomain(givenUserDto);
            var user = await _loginRepository.GetUserByEmail(domainNewUser.Email);
            if (user == null)
            {
                return AuthResponseFactory.Fail("Incorrect email or password entered. Please try again.");
            }

            // Verify password
            bool isValid = _hasher.VerifyPassword(user.Password, domainNewUser.HashedPassword);
            if (!isValid)
            {
                return AuthResponseFactory.Fail("Incorrect email or password entered. Please try again.");
            }

            // Successful Login
            return AuthResponseFactory.Success();
        }
    }
}
