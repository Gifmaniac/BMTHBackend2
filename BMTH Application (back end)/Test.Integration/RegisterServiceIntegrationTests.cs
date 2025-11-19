using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

using DataLayer.Context;
using DataLayer.Repositories.User;
using DataLayer.Models.User;
using BusinessLayer.Services.User;
using BusinessLayer.Helper.Validator.User;
using BusinessLayer.Services.Helper;
using Contracts.DTOs.User;
using Contracts.Enums.User;

namespace Test.Integration.Register;

public class RegisterServiceIntegrationTests
{

    // Create fresh in-memory SQLite DB
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


    // TEST 1 — Successful registration
    [Fact]
    public async Task RegisterUser_SavesUser_WhenValid()
    {
        // Arrange
        var db = CreateTestDb();
        var repo = new UserRegisterRepository(db);

        var validator = new RegisterValidator();
        var hasher = new PasswordHasherService();

        var service = new RegisterService(validator, hasher, repo);

        var dto = new RegisterDto
        {
            Email = "test@example.com",
            Password = "Password123!",
            FirstName = "John",
            LastName = "Doe"
        };

        // Act
        var (success, errors) = await service.RegisterUser(dto);

        // Assert
        Assert.True(success);
        Assert.Empty(errors);

        var saved = db.Users.Single(x => x.Email == "test@example.com");

        Assert.NotEqual(dto.Password, saved.Password);
        Assert.False(string.IsNullOrWhiteSpace(saved.Password));

        Assert.Equal(Roles.User, saved.Role);
        Assert.Equal("John", saved.FirstName);
        Assert.Equal("Doe", saved.LastName);

        db.Database.CloseConnection();
    }


    // TEST 2 — Validation fails
        [Fact]
    public async Task RegisterUser_ReturnsErrors_WhenInputInvalid()
    {
        // Arrange
        var db = CreateTestDb();
        var repo = new UserRegisterRepository(db);

        var hasher = new Mock<IPasswordHasherService>();
        var validator = new RegisterValidator();

        var service = new RegisterService(validator, hasher.Object, repo);

        var dto = new RegisterDto
        {
            Email = "invalid",
            Password = "123",  // fails every rule
            FirstName = "",
            LastName = ""
        };

        // Act
        var (success, errors) = await service.RegisterUser(dto);

        // Assert
        Assert.False(success);
        Assert.NotEmpty(errors);
        Assert.True(errors.Count >= 4); // Email, Password rules, FirstName, LastName

        db.Database.CloseConnection();
    }

    // TEST 3 — Email already exists
    [Fact]
    public async Task RegisterUser_Fails_WhenEmailExists()
    {
        // Arrange
        var db = CreateTestDb();

        db.Users.Add(new UserModel()
        {
            Email = "taken@example.com",
            Password = "pw",
            FirstName = "First",
            LastName = "Last",
            Role = Roles.User,
            CreatedAt = DateTime.UtcNow
        });

        db.SaveChanges();

        var repo = new UserRegisterRepository(db);
        var hasher = new Mock<IPasswordHasherService>();
        var validator = new RegisterValidator();

        var service = new RegisterService(validator, hasher.Object, repo);

        var dto = new RegisterDto
        {
            Email = "taken@example.com",
            Password = "Password1!",
            FirstName = "New",
            LastName = "User"
        };

        // Act
        var (success, errors) = await service.RegisterUser(dto);

        // Assert
        Assert.False(success);
        Assert.Single(errors);
        Assert.Equal("Email already exists", errors[0]);

        db.Database.CloseConnection();
    }
}
