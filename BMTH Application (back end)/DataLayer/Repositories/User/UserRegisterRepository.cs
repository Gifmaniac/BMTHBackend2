using DataLayer.Context;
using DataLayer.Interfaces.User;
using DataLayer.Models.User;

namespace DataLayer.Repositories.User
{
    public class UserRegisterRepository(StoreDbContext context) : IUserRegisterRepository
    {
        private readonly StoreDbContext _context = context;

        public async Task<UserRegisterModel> RegisterUserTask(UserRegisterModel newUser)
        {
            return await Task.FromResult(newUser);
        }

        public async Task<bool> DoesEmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);

        }


    }
}
