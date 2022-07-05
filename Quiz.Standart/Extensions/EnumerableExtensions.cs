using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Standart.Extensions
{
    public static class EnumerableExtensions
    {
        private static readonly Random Randomize = new Random();

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> values, int? times = null)
        {
            var result = values.ToArray();
            var shufflingTimes = times is null || times <= 0 ? result.Length : times;

            for (var i = 0; i < shufflingTimes; ++i)
            {
                var (firstPos, secondPos) = (Randomize.Next(result.Length), Randomize.Next(result.Length));
                (result[firstPos], result[secondPos]) = (result[secondPos], result[firstPos]);
            }

            return result;
        }
    }
}
