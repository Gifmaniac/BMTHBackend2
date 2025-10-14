
namespace BusinessLayer.Helper
{
    public static class EnumHelper
    {
        // This will help me convert the Dto information to an enum
        // It also returns a default value if the string isn't correct.
        public static TEnum ParseEnum<TEnum>(string? value, TEnum defaultValue) where TEnum : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            if (Enum.TryParse<TEnum>(value, true, out var result))
            {
                return result;
            }

            return defaultValue;
        }
    }
}
