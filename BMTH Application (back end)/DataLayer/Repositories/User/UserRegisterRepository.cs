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
            _context.UserRegister.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<bool> DoesEmailExists(string email)
        {
            return await Task.FromResult(_context.UserRegister.Any(u => u.Email == email));
        }
    }
}
