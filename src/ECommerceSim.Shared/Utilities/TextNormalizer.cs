using System.Globalization;
using System.Text;

namespace ECommerceSimProject2.src.ECommerceSim.Shared.Utilities
{
    public static class TextNormalizer
    {
        public static string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            var normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var item in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(item);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark && char.IsLetterOrDigit(item))
                {
                    sb.Append(char.ToLowerInvariant(item));
                }
            }
            return sb.ToString();
        }
    }
}
