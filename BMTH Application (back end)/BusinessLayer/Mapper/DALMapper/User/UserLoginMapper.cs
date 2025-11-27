using BusinessLayer.Domain.User;
using DataLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapper.DALMapper.User
{
    public class UserLoginMapper
    {
        public static LoginUser ToDomain(UserModel model)
        {
            return new LoginUser
            {
                Id = model.UserId,
                Email = model.Email,
                HashedPassword = model.Password,
                Role = model.Role
            };
        }
    }
}
