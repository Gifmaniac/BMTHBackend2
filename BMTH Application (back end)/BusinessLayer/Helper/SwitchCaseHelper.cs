using BusinessLayer.Exceptions;
using Contracts.Enums.Store;

namespace BusinessLayer.Helper
{
    public static class SwitchCaseHelper
    {
        public static Genders SetGender(string genderPath)
        {
            if (Enum.TryParse<Genders>(genderPath, true, out var gender))
            {
                return gender;
            }

            throw new NotFoundException($"Invalid gender: {genderPath}");
        }

        public static StoreCategoryType SetStoreCategoryType(string categoryType)
        {
            if (Enum.TryParse<StoreCategoryType>(categoryType, true, out var category))
            {
                return category;
            }

            throw new NotFoundException($"Invalid gender: { categoryType }");
        }
    }
}
