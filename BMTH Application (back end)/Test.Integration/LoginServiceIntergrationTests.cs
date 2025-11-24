using BusinessLayer.Helper.Validator.User;
using BusinessLayer.Services.User;
using Contracts.DTOs.User;
using Contracts.Enums.User;
using DataLayer.Context;
using DataLayer.Models.User;
using DataLayer.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace Test.Integration
{
    namespace Test.Integration.Login
    {
        public class LoginServiceIntegrationTests
        {
            private StoreDbContext CreateTestDb()
            {
                var options = new DbContextOptionsBuilder<StoreDbContext>()
                    .UseSqlite("Filename=:memory:")
                    .Options;

                var db = new StoreDbContext(options);
                db.Database.OpenConnection();
                db.Database.EnsureCreated();
                return db;
            }

            // TEST 1 — Successful login
            [Fact]
            public async Task LoginUser_ReturnsSuccess_WhenCredentialsMatch()
            {
                // Arrange
                var db = CreateTestDb();
                var repo = new UserLoginRepository(db);

                var validator = new LoginValidator();
                var hasher = new PasswordHasherService();

                // Create user with hashed password
                var hashedPassword = hasher.HashPassword("Password123!");

                db.Users.Add(new UserModel
                {
                    Email = "user@test.com",
                    Password = hashedPassword,
                    FirstName = "John",
                    LastName = "Doe",
                    Role = Roles.User,
                    CreatedAt = DateTime.UtcNow
                });

                db.SaveChanges();

                var service = new LoginService(validator, hasher, repo);

                var dto = new LoginUserDto
                {
                    Email = "user@test.com",
                    Password = "Password123!"
                };

                // Act
                var response = await service.LoginUser(dto);

                // Assert
                Assert.True(response.Success);
                Assert.Empty(response.AuthList);

                db.Database.CloseConnection();
            }

            // TEST 2 — Validation fails
            [Fact]
            public async Task LoginUser_ReturnsErrors_WhenInputInvalid()
            {
                // Arrange
                var db = CreateTestDb();
                var repo = new UserLoginRepository(db);

                var validator = new LoginValidator();
                var hasher = new PasswordHasherService();

                var service = new LoginService(validator, hasher, repo);

                var dto = new LoginUserDto
                {
                    Email = "invalid-email",
                    Password = ""
                };

                // Act
                var response = await service.LoginUser(dto);

                // Assert
                Assert.False(response.Success);
                Assert.NotEmpty(response.AuthList);

                db.Database.CloseConnection();
            }

            // TEST 3 — Email does not exist
            [Fact]
            public async Task LoginUser_Fails_WhenUserNotFound()
            {
                // Arrange
                var db = CreateTestDb();
                var repo = new UserLoginRepository(db);

                var validator = new LoginValidator();
                var hasher = new PasswordHasherService();

                var service = new LoginService(validator, hasher, repo);

                var dto = new LoginUserDto
                {
                    Email = "unknown@test.com",
                    Password = "Password123!"
                };

                // Act
                var response = await service.LoginUser(dto);

                // Assert
                Assert.False(response.Success);
                Assert.Single(response.AuthList);
                Assert.Equal("Incorrect username or password entered. Please try again.", response.AuthList[0]);

                db.Database.CloseConnection();
            }

            // TEST 4 — Password mismatch
            [Fact]
            public async Task LoginUser_Fails_WhenPasswordIncorrect()
            {
                // Arrange
                var db = CreateTestDb();
                var repo = new UserLoginRepository(db);

                var validator = new LoginValidator();
                var hasher = new PasswordHasherService();

                // Store user with correct password "Password123!"
                db.Users.Add(new UserModel
                {
                    Email = "user@test.com",
                    Password = hasher.HashPassword("Password123!"),
                    FirstName = "John",
                    LastName = "Doe",
                    Role = Roles.User,
                    CreatedAt = DateTime.UtcNow
                });

                db.SaveChanges();

                var service = new LoginService(validator, hasher, repo);

                var dto = new LoginUserDto
                {
                    Email = "user@test.com",
                    Password = "WrongPassword!"
                };

                // Act
                var response = await service.LoginUser(dto);

                // Assert
                Assert.False(response.Success);
                Assert.Single(response.AuthList);
                Assert.Equal("Incorrect username or password entered. Please try again.", response.AuthList[0]);

                db.Database.CloseConnection();
            }
        }
    }
}
