using FluentValidation.TestHelper;
using BusinessLayer.Helper.Validator.User;
using BusinessLayer.Domain.User;
using Contracts.Enums.User;

namespace Test.Unit
{
    public class RegisterValidatorTests
    {
        private readonly RegisterValidator _validator;

        public RegisterValidatorTests()
        {
            _validator = new RegisterValidator();
        }

        private Register CreateValidRegister()
        {
            return new Register
            {
                Email = "valid@example.com",
                Password = "StrongP@ssword1",
                FirstName = "John",
                LastName = "Doe"
            };
        }

        // EMAIL TESTS
        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            var model = CreateValidRegister();
            model.Email = "";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            var model = CreateValidRegister();
            model.Email = "invalidmail.com";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Email_Is_Valid()
        {
            var model = CreateValidRegister();

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        // PASSWORD TESTS
        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            var model = CreateValidRegister();
            model.Password = "";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Too_Weak()
        {
            var model = CreateValidRegister();
            model.Password = "weakpassword";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Password_Is_Strong()
        {
            var model = CreateValidRegister();

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }

        // FIRST NAME
        [Fact]
        public void Should_Have_Error_When_FirstName_Is_Empty()
        {
            var model = CreateValidRegister();
            model.FirstName = "";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void Should_Not_Have_Error_When_FirstName_Is_Valid()
        {
            var model = CreateValidRegister();

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }

        // LAST NAME
        [Fact]
        public void Should_Have_Error_When_LastName_Is_Empty()
        {
            var model = CreateValidRegister();
            model.LastName = "";

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void Should_Not_Have_Error_When_LastName_Is_Valid()
        {
            var model = CreateValidRegister();

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.LastName);
        }
    }
}