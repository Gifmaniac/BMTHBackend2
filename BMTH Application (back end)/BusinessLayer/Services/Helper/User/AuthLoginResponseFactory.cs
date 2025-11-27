using Contracts.DTOs.Responses;

namespace BusinessLayer.Services.Helper.User
{
    public static class AuthLoginResponseFactory
    {
        public static AuthLoginResponseDto Success(string token, string email, string role)
        {
            return new AuthLoginResponseDto
            {
                Success = true,
                Token = token,
                Email = email,
                Role = role,
                AuthList = new List<string>()
            };
        }

        public static AuthLoginResponseDto Fail(List<string> errors)
        {
            return new AuthLoginResponseDto
            {
                Success = false,
                AuthList = errors
            };
        }

        public static AuthLoginResponseDto Fail(string error)
        {
            return new AuthLoginResponseDto
            {
                Success = false,
                AuthList = new List<string> { error }
            };
        }
    }
}