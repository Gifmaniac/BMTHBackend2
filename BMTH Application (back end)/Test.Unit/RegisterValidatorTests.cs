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

        // EMAIL TESTS
        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            var model = new Register { Email = "" };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            var model = new Register { Email = "invalid-email" };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Email_Is_Valid()
        {
            var model = new Register { Email = "test@example.com" };

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        // PASSWORD TESTS
        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            var model = new Register { Password = "" };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Too_Weak()
        {
            var model = new Register { Password = "weakpass" };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Password_Is_Strong()
        {
            var model = new Register { Password = "StrongP@ssword1" };

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Password);
        }

        // FIRST NAME
        [Fact]
        public void Should_Have_Error_When_FirstName_Is_Empty()
        {
            var model = new Register { FirstName = "" };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.FirstName);
        }

        [Fact]
        public void Should_Not_Have_Error_When_FirstName_Is_Valid()
        {
            var model = new Register { FirstName = "John" };

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
        }

        // LAST NAME
        [Fact]
        public void Should_Have_Error_When_LastName_Is_Empty()
        {
            var model = new Register { LastName = "" };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.LastName);
        }

        [Fact]
        public void Should_Not_Have_Error_When_LastName_Is_Valid()
        {
            var model = new Register { LastName = "Doe" };

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.LastName);
        }
    }
}