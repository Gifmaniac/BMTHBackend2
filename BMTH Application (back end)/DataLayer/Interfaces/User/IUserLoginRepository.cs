using DataLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.User
{
    public interface IUserLoginRepository
    {
        Task<UserModel?> GetUserByEmail(string email);
    }
}
