
using BusinessLayer.Domain.User;
using DataLayer.Models.User;

namespace BusinessLayer.Mapper.DALMapper.User
{
    public static class UserRegisterMapper
    {
        public static UserRegisterModel ToModel(Register domain)
        {
            return new UserRegisterModel
            {
                Email = domain.Email,
                Password = domain.Password,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                Role = domain.Role,
                CreatedAt = domain.CreatedAt
            };
        }
    }
}
