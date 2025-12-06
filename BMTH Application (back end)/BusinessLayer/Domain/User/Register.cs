
using Contracts.Enums.User;

namespace BusinessLayer.Domain.User
{
    public class Register
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public Roles Role { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
