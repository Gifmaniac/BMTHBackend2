using Contracts.DTOs.Responses;

namespace BusinessLayer.Services.Helper.User
{
    public static class AuthResponseFactory
    {
        public static T Success<T>() where T : IAuthResponse, new()
        {
            return new T
            {
                Success = true,
                AuthList = new List<string>()
            };
        }

        public static T Fail<T>(List<string> errors) where T : IAuthResponse, new()
        {
            return new T
            {
                Success = false,
                AuthList = errors
            };
        }

        public static T Fail<T>(string error) where T : IAuthResponse, new()
        {
            return new T
            {
                Success = false,
                AuthList = new List<string> { error }
            };
        }
    }
}
