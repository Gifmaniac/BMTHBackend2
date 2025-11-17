
using Contracts.Enums.User;

namespace BusinessLayer.Domain.User
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
    }
}
