using Contracts.DTOs.Responses;
using Contracts.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces.User
{
    public interface ILoginService
    {
        public Task<AuthLoginResponseDto> LoginUser(LoginUserDto givenUserDto);
    }
}
