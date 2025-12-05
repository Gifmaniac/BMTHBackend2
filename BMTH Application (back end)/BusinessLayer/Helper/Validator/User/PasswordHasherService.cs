using BusinessLayer.Domain.User;
using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces.Helper;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Helper.Validator.User
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly PasswordHasher<Register> _hasher;
       
        private static readonly Register DummyUser = new Register
        {
            Email = "dummy@example.com",
            Password = "dummy",
            LastName = "dummy",
            FirstName = "test"
        };

        public PasswordHasherService()
        {
            _hasher = new PasswordHasher<Register>();
        }

        public string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ValidationException("Password cannot be null.");
            }

            return _hasher.HashPassword(DummyUser, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == null)
            {
                throw new ValidationException("Password cannot be null.");
            }
            var result = _hasher.VerifyHashedPassword(DummyUser, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}