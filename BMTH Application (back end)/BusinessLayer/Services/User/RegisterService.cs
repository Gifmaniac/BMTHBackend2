using BusinessLayer.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces.User;
using FluentValidation;

namespace BusinessLayer.Services.User
{
    public class RegisterService(IValidator<Register> validator) : IRegisterService
    {
        private readonly IValidator<Register> _validator = validator;
        public (bool Success, List<string> errors) RegisterUser(Register newUser)
        {
            var result = _validator.Validate(newUser);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return (false, errors);
            }
            
            return (true, new List<string>());
        }
    }
}
