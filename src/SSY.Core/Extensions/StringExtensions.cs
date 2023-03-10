namespace SSY.Common.Extensions
{
    public static class StringExtensions
    {
        public static string EnsureEndsWith(this string str, char c) => str.EnsureEndsWith(c, StringComparison.Ordinal);

        /// <summary>
        /// Adds a char to end of given string if it does not ends with the char.
        /// </summary>
        public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            return str.EndsWith(c.ToString(), comparisonType) ? str : str + c.ToString();
        }
    }
}
