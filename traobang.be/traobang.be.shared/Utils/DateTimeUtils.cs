using System.Globalization;

namespace traobang.be.shared.Utils
{
    public static class DateTimeUtils
    {
        public static DateTime? ParseVietnamDate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            string[] formats =
            {
                "dd/MM/yyyy",
                "dd/MM/yy"
            };

            if (DateTime.TryParseExact(
                input.Trim(),
                formats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime result))
            {
                return result;
            }

            return null;
        }
    }
}
