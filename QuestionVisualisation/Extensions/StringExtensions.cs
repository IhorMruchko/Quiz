using System.Collections.Generic;

namespace QuestionVisualisation.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string value)
        {
            return int.TryParse(value, out var result)
                ? result
                : 0;
        }

        public static string Join<T>(this IEnumerable<T> enumerate, string connectionSymbol="")
        {
            return string.Join(connectionSymbol, enumerate);
        } 
    }
}
