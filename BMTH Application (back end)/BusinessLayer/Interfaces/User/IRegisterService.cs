using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Domain.User;

namespace BusinessLayer.Interfaces.User
{
    public interface IRegisterService
    {
        public (bool Succes, List<string> errors) VerifyRegister(Register newUser);
        public (bool Success, List<string> errors) RegisterUser(Register newUser);
    }
}
