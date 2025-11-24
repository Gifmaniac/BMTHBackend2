using BusinessLayer.Domain.User;
using Contracts.DTOs.User;

namespace BusinessLayer.Mapper.ApiMapper.StoreItems.User
{
    public class LoginUserApiMapper
    {
        public static LoginUserDto ToDto(LoginUser loginUser)
        {
            return new LoginUserDto()
            {
                Email = loginUser.Email,
                Password = loginUser.HashedPassword
            };
        }

        public static LoginUser toDomain(LoginUserDto loginUserDto)
        {
            return new LoginUser()
            {
                Email = loginUserDto.Email,
                HashedPassword = loginUserDto.Password
            };
        }
    }
}
