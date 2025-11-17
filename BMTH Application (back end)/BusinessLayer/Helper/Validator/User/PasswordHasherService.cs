using BusinessLayer.Domain.User;
using BusinessLayer.Services.Helper;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Helper.Validator.User
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly PasswordHasher<Register> _hasher;

        public PasswordHasherService()
        {
            _hasher = new PasswordHasher<Register>();
        }

        public string HashPassword(string password)
        {

            return _hasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}