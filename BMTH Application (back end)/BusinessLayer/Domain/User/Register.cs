
namespace BusinessLayer.Domain.User
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly BirthDay { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }
    }
}
