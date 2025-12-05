using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs.Responses
{
    public class AuthLoginResponseDto : IAuthResponse
    {
        public bool Success { get; set; }
        public required string Token { get; set; }
        public required List<string> AuthList { get; set; }
    }
}
