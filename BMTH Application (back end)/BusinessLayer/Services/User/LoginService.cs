using BusinessLayer.Interfaces.Helper;
using BusinessLayer.Interfaces.User;
using BusinessLayer.Mapper.ApiMapper.StoreItems.User;
using BusinessLayer.Mapper.DALMapper.User;
using BusinessLayer.Services.Helper.User;
using Contracts.DTOs.Responses;
using Contracts.DTOs.User;
using DataLayer.Interfaces.User;
using FluentValidation;

namespace BusinessLayer.Services.User
{
    public class LoginService(IValidator<LoginUserDto> validator, IPasswordHasherService passwordHasherService, IUserLoginRepository loginRepository, IJwtTokenGenerator tokenGenerator) : ILoginService
    {
        private readonly IPasswordHasherService _hasher = passwordHasherService;
        private readonly IValidator<LoginUserDto> _validator = validator;
        private readonly IUserLoginRepository _loginRepository = loginRepository;
        private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;

        public async Task<AuthLoginResponseDto> LoginUser(LoginUserDto givenUserDto)
        {
            // Validates the user input if correct
            var result = _validator.Validate(givenUserDto);
            if (!result.IsValid)
            {
                return AuthResponseFactory.Fail<AuthLoginResponseDto>(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            // Checks if account exist and the password matches
            var domainUser = LoginUserApiMapper.toDomain(givenUserDto);
            var user = await _loginRepository.GetUserByEmail(domainUser.Email);
            if (user == null)
            {
                return AuthResponseFactory.Fail<AuthLoginResponseDto>("Incorrect email or password entered. Please try again.");
            }

            var domainDalUser = UserLoginMapper.ToDomain(user);

            // Verify password
            bool isValid = _hasher.VerifyPassword(domainDalUser.HashedPassword, domainUser.HashedPassword);
            if (!isValid)
            {
                return AuthResponseFactory.Fail<AuthLoginResponseDto>("Incorrect email or password entered. Please try again.");
            }

            // Successful Login
            var responseDto = new AuthLoginResponseDto
            {
                Success = true,
                Token = _tokenGenerator.GenerateToken(domainDalUser),
                AuthList = new()
            };


            return AuthResponseFactory.Success(responseDto);
        }
    }
}
