using BusinessLayer.Exceptions;
using Contracts.Enums.Store;

namespace BusinessLayer.Helper.Validator.Store
{
    public static class MerchandiseValidator
    {
        public static Genders ValidateGender(string? genderString)
        {
            if (string.IsNullOrWhiteSpace(genderString))
            {
                throw new ValidationException("Gender is required.");
            }

            if (!Enum.TryParse<Genders>(genderString, true, out var gender))
            {
                throw new ValidationException($"Invalid gender '{genderString}'.");
            }
            return gender;
        }
    }
}
