using Contracts.DTOs.Responses;

namespace BusinessLayer.Services.Helper.User
{
    public static class AuthResponseFactory
    {
        public static AuthResponseDto Success()
        {
            return new AuthResponseDto
            {
                Success = true,
                AuthList = new List<string>()
            };
        }

        public static AuthResponseDto Fail(List<string> errors)
        {
            return new AuthResponseDto
            {
                Success = false,
                AuthList = errors
            };
        }

        public static AuthResponseDto Fail(string error)
        {
            return new AuthResponseDto
            {
                Success = false,
                AuthList = new List<string> { error }
            };
        }
    }
}
