using BusinessLayer.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces.User;

namespace BusinessLayer.Services.User
{
    public class RegisterService : IRegisterService
    {
        public (bool Succes, List<string> errors) VerifyRegister(Register newUser)
        {
            var errors = new List<string>();

            var normalizedEmail = newUser.Email.ToLowerInvariant();

            if (!errors.Any())
            {
                errors.Add("A user already exists with this email or username.");
            }

            return (errors.Count == 0, errors);
        }
        public (bool Succes, List<string> Errors) RegisterUser(Register newUser)
        {
            var (isValid, errors) = VerifyRegister(newUser);

            if (!isValid)
            {
                return (false, errors);
            }

            return (true, errors);

        }

    }
}
