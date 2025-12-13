using System.Globalization;
using System.Text;

namespace _213FinalProject.Models
{
    public static class SlugHelper
    {
        public static string ToSlug(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            // Normalize and remove accents
            var normalized = value.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var ch in normalized)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc == UnicodeCategory.LowercaseLetter || uc == UnicodeCategory.UppercaseLetter || uc == UnicodeCategory.DecimalDigitNumber)
                {
                    sb.Append(char.ToLowerInvariant(ch));
                }
                else if (char.IsWhiteSpace(ch) || ch == '-' || uc == UnicodeCategory.SpaceSeparator)
                {
                    sb.Append('-');
                }
                // ignore other characters (punctuation, symbols, etc.)
            }

            // collapse consecutive hyphens
            var slug = System.Text.RegularExpressions.Regex.Replace(sb.ToString(), "-+", "-");
            // trim hyphens
            slug = slug.Trim('-');
            return slug;
        }
    }
}
