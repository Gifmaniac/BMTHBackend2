using Contracts.DTOs.Responses;

namespace BusinessLayer.Mapper.ApiMapper.Auth
{
    public class AuthResponseMapper
    {
        public static AuthResponseDto ResponseDtoMap((bool Success, List<string> Errors) result)
        {

            return new AuthResponseDto()
            {
                AuthList = result.Errors,
                Success = result.Success
            };
        }
    }
}
