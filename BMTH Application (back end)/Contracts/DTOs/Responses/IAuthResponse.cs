 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs.Responses
{
    public interface IAuthResponse
    {
        bool Success { get; set; }
        List<string> AuthList { get; set; }
    }
}
