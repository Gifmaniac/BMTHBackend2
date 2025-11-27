using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DataLayer.Context;
using DataLayer.Repositories.User;
using DataLayer.Models.User;
using BusinessLayer.Services.User;
using BusinessLayer.Helper.Validator.User;
using Contracts.DTOs.User;
using Contracts.Enums.User;
using BusinessLayer.Interfaces.Helper;
using Contracts.DTOs.Responses;
using Moq; // <-- needed for AuthResponseDto

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

        var dto = new RegisterUserDto
        {
            Email = "test@example.com",
            Password = "Password123!",
            FirstName = "John",
            LastName = "Doe"
        };

        // Act
        var response = await service.RegisterUser(dto);

        // Assert
        Assert.True(response.Success);
        Assert.Empty(response.AuthList);

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

        var dto = new RegisterUserDto
        {
            Email = "invalid",
            Password = "123",
            FirstName = "",
            LastName = ""
        };

        // Act
        var response = await service.RegisterUser(dto);

        // Assert
        Assert.False(response.Success);
        Assert.NotEmpty(response.AuthList);
        Assert.True(response.AuthList.Count >= 4);

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

        var dto = new RegisterUserDto
        {
            Email = "taken@example.com",
            Password = "Password1!",
            FirstName = "New",
            LastName = "User"
        };

        // Act
        var response = await service.RegisterUser(dto);

        // Assert
        Assert.False(response.Success);
        Assert.Single(response.AuthList);
        Assert.Equal("Email already exists", response.AuthList[0]);

        db.Database.CloseConnection();
    }
}
