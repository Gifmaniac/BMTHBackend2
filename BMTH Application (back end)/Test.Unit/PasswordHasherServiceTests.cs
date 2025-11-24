using BusinessLayer.Helper;
using BusinessLayer.Helper.Validator.User;
using BusinessLayer.Interfaces.Helper;

namespace Test.Unit
{
    public class PasswordHasherServiceTests
    {
        private readonly IPasswordHasherService _hasher;

        public PasswordHasherServiceTests()
        {
            _hasher = new PasswordHasherService();
        }


        // HASHING TESTS
        [Fact]
        public void HashPassword_Should_Return_Hashed_Value()
        {
            // Arrange
            var password = "MyTestPassword123!";

            // Act
            var hashed = _hasher.HashPassword(password);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(hashed));
            Assert.NotEqual(password, hashed);
        }

        [Fact]
        public void HashPassword_SamePassword_Should_Produce_Different_Hash_Each_Time()
        {
            // Arrange
            var password = "Repeat123!";

            // Act
            var hash1 = _hasher.HashPassword(password);
            var hash2 = _hasher.HashPassword(password);

            // Assert
            Assert.NotEqual(hash1, hash2); // PBKDF2 uses salt, every hash is different
        }


        // VERIFY TESTS
        [Fact]
        public void VerifyPassword_Should_Return_True_For_Correct_Password()
        {
            // Arrange
            var password = "CorrectPassword123!";
            var hashed = _hasher.HashPassword(password);

            // Act
            var result = _hasher.VerifyPassword(hashed, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPassword_Should_Return_False_For_Wrong_Password()
        {
            // Arrange
            var hashed = _hasher.HashPassword("RightPassword123!");

            // Act
            var result = _hasher.VerifyPassword(hashed, "WrongPassword!");

            // Assert
            Assert.False(result);
        }
    }
}