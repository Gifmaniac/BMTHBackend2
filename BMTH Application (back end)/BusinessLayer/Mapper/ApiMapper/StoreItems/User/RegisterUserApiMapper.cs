
using BusinessLayer.Domain.User;
using Contracts.DTOs.User;

namespace BusinessLayer.Mapper.ApiMapper.StoreItems.User
{
    public static class RegisterUserApiMapper
    {
        public static Register ToDomain(RegisterDto dto)
        {
            return new Register
            {
                Email = dto.Email,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        }
    }
}
