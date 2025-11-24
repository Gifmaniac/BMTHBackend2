using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DataLayer.Interfaces.User;
using DataLayer.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.User
{
    public class UserLoginRepository(StoreDbContext context) : IUserLoginRepository
    {
        private readonly StoreDbContext _context = context;

        public async Task<UserModel?> GetUserByEmail(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
