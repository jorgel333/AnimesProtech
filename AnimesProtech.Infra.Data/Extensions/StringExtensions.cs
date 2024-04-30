using System.Globalization;
using System.Text;

namespace AnimesProtech.Application.Extensions;

public static class StringExtensions
{
    public static string RemoveAccents(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        input = input.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (char c in input)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                stringBuilder.Append(c);
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}
