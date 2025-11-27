namespace Contracts.DTOs.Responses
{
    public class AuthResponseDto : IAuthResponse
    {
        public bool Success { get; set; }
        public List<string> AuthList { get; set; }
    }
}
