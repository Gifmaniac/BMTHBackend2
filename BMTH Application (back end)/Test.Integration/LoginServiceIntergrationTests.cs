using BusinessLayer.Helper.Validator.User;
using BusinessLayer.Services.User;
using Contracts.DTOs.User;
using Contracts.Enums.User;
using DataLayer.Context;
using DataLayer.Models.User;
using DataLayer.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;



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

            private IConfiguration BuildFakeConfig()
            {
                return new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string>
                    {
                        { "JwtSettings:Key", "TestKey12384784_Needs_To_Be_Longer_Lmao" },
                        { "JwtSettings:Issuer", "TestIssuer" },
                        { "JwtSettings:Audience", "TestAudience" },
                        { "JwtSettings:ExpiryMinutes", "60" }
                    })
                    .Build();
            }

            // TEST 1 — Successful login
            [Fact]
            public async Task LoginUser_ReturnsSuccess_WhenCredentialsMatch()
            {
                // Arrange
                var db = CreateTestDb();
                var repo = new UserLoginRepository(db);
                var token = new JwtTokenGenerator(BuildFakeConfig());
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

                var service = new LoginService(validator, hasher, repo, token);

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
                Assert.Equal(3, response.Token.Split('.').Length);

                db.Database.CloseConnection();
            }

            // TEST 2 — Validation fails
            [Fact]
            public async Task LoginUser_ReturnsErrors_WhenInputInvalid()
            {
                // Arrange
                var db = CreateTestDb();
                var repo = new UserLoginRepository(db);
                var token = new JwtTokenGenerator(BuildFakeConfig());
                var validator = new LoginValidator();
                var hasher = new PasswordHasherService();

                var service = new LoginService(validator, hasher, repo, token);

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
                var token = new JwtTokenGenerator(BuildFakeConfig());
                var validator = new LoginValidator();
                var hasher = new PasswordHasherService();

                var service = new LoginService(validator, hasher, repo, token );

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
                Assert.Equal("Incorrect email or password entered. Please try again.", response.AuthList[0]);

                db.Database.CloseConnection();
            }

            // TEST 4 — Password mismatch
            [Fact]
            public async Task LoginUser_Fails_WhenPasswordIncorrect()
            {
                // Arrange
                var db = CreateTestDb();
                var repo = new UserLoginRepository(db);
                var token = new JwtTokenGenerator(BuildFakeConfig());
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

                var service = new LoginService(validator, hasher, repo, token);

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
                Assert.Equal("Incorrect email or password entered. Please try again.", response.AuthList[0]);

                db.Database.CloseConnection();
            }
        }
    }
}
