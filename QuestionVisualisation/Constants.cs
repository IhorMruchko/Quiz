using System;
using System.IO;
using System.Windows.Media;

namespace QuestionVisualisation
{
    public static class Constants
    {
        public static readonly string DataFileName = "Quizz.json";

        public static readonly string InitialDirectory = Path.Combine(Environment.CurrentDirectory, DataFileName);

        public static class Colors
        {
            public static readonly Brush White = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            public static readonly Brush Black = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            public static readonly Brush Purple = new SolidColorBrush(Color.FromRgb(124, 49, 204));

            public static readonly Brush LightRed = new SolidColorBrush(Color.FromRgb(252, 215, 215));

            public static readonly Brush Transparent = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

            public static readonly Brush LightGreen = new SolidColorBrush(Color.FromRgb(208, 247, 215));
        }
    }
}
