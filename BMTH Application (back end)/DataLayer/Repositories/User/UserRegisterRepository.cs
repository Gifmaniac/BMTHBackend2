using DataLayer.Context;
using DataLayer.Interfaces.User;
using DataLayer.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.User
{
    public class UserRegisterRepository(StoreDbContext context) : IUserRegisterRepository
    {
        private readonly StoreDbContext _context = context;

        public async Task<UserModel> RegisterUserTask(UserModel newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<bool> DoesEmailExists(string email)
        {
            var normalized = email.Trim().ToLower();
            return await _context.Users.AnyAsync(u => u.Email.ToLower() == normalized);
        }
    }
}
