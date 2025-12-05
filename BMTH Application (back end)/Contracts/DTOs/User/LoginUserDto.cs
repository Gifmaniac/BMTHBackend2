namespace Contracts.DTOs.User
{
    public class LoginUserDto
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
