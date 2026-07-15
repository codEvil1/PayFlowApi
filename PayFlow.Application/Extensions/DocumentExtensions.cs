using System.Text.RegularExpressions;

namespace PayFlow.Application.Extensions
{
    public static partial class DocumentExtensions
    {
        public static string OnlyDigits(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return Cnpj().Replace(value, "");
        }

        [GeneratedRegex(@"[^0-9]")]
        private static partial Regex Cnpj();
    }
}