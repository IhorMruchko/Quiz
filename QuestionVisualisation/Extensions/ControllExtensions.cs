using System.Windows.Controls;
using System.Windows.Media;

namespace QuestionVisualisation.Extensions
{
    public static class ControllExtensions
    {
        public static void ChangeColors<T>(this T controller, Brush? backColor = null, Brush? foreColor = null)
            where T : Control
        {
            controller.Background = backColor ?? controller.Background;
            controller.Foreground = foreColor ?? controller.Foreground;
        }
    }
}
