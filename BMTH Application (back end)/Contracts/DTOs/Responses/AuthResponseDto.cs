namespace Contracts.DTOs.Responses
{
    public class AuthResponseDto : IAuthResponse
    {
        public bool Success { get; set; }
        public required List<string> AuthList { get; set; }
    }
}
