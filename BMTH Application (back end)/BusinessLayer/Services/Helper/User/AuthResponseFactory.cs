using Contracts.DTOs.Responses;

namespace BusinessLayer.Services.Helper.User
{
    public static class AuthResponseFactory
    {
        public static T Success<T>(T response) where T : IAuthResponse
        {
            response.Success = true;
            response.AuthList = new List<string>();
            return response;
        }

        public static T Fail<T>(List<string> errors) where T : IAuthResponse
        {
            var response = (T)Activator.CreateInstance(typeof(T), nonPublic: true)!;
            response.Success = false;
            response.AuthList = errors;
            return response;
        }


        public static T Fail<T>(string error) where T : IAuthResponse
        {
            return Fail<T>(new List<string> { error });
        }

    }
}
