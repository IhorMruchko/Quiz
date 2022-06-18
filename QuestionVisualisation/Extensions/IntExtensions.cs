namespace QuestionVisualisation.Extensions
{
    public static class IntExtensions
    {
        public static bool Between(this int value, int minValue, int maxValue)
        {
            (minValue, maxValue) = minValue < maxValue
                ? (minValue, maxValue)
                : (maxValue, minValue);

            return value >= minValue && value <= maxValue;
        }
    }
}
