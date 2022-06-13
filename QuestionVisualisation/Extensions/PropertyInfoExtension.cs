using System.Reflection;

namespace QuestionVisualisation.Extensions
{
    public static class PropertyInfoExtension
    {
        public static bool TrySetValue(this PropertyInfo property, object? objectToSet, object? value)
        {
            try
            {
                property.SetValue(objectToSet, value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
