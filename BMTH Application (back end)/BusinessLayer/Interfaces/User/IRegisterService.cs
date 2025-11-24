using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Domain.User;
using Contracts.DTOs.Responses;
using Contracts.DTOs.User;

namespace BusinessLayer.Interfaces.User
{
    public interface IRegisterService
    {
        public Task<AuthResponseDto> RegisterUser(RegisterUserDto newUserdDto);
    }
}
