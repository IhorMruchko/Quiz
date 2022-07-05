using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Quiz.Standart;

public static class WPFConstants
{
    public static class Colors
    {
        public static readonly Brush Black = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        public static readonly Brush LightRed = new SolidColorBrush(Color.FromRgb(252, 215, 215)); // #FCD7D7
        public static readonly Brush LightGreen = new SolidColorBrush(Color.FromRgb(208, 247, 215)); // #D0F7D7
        public static readonly Brush Purple = new SolidColorBrush(Color.FromRgb(124, 49, 204));
        public static readonly Brush Transparent = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        public static readonly Brush White = new SolidColorBrush(Color.FromRgb(255, 255, 255));
    }

    public static class Images
    {
        private static readonly string ImageSource = @"pack://application:,,,/Quiz.Visual;component/Resources/Images/";
        public static readonly BitmapImage AddIcon = new(new(ImageSource + "add-icon.png"));
        public static readonly BitmapImage AddIconFilled = new(new(ImageSource + "add-icon-filled.png"));
        public static readonly BitmapImage AddTopicIcon = new(new(ImageSource + "add-topic-icon.png"));
        public static readonly BitmapImage AddQuestionIcon = new(new(ImageSource + "add-question-icon.png"));
        public static readonly BitmapImage BackIcon = new(new(ImageSource + "back-icon.png"));
        public static readonly BitmapImage CheckedIcon = new(new(ImageSource + "checked-icon.png"));
        public static readonly BitmapImage CorrectIcon = new(new(ImageSource + "correct-icon.png"));
        public static readonly BitmapImage DeleteIcon = new(new(ImageSource + "delete-icon.png"));
        public static readonly BitmapImage EditIcon = new(new(ImageSource + "edit-icon.png"));
        public static readonly BitmapImage EditIconFilled = new(new(ImageSource + "edit-icon-filled.png"));
        public static readonly BitmapImage FinishIcon = new(new(ImageSource + "finish-icon.png"));
        public static readonly BitmapImage NextIcon = new(new(ImageSource + "next-icon.png"));
        public static readonly BitmapImage OpenIcon = new(new(ImageSource + "open-icon.png"));
        public static readonly BitmapImage PreviousIcon = new(new(ImageSource + "previous-icon.png"));
        public static readonly BitmapImage SaveIcon = new(new(ImageSource + "save-icon.png"));
        public static readonly BitmapImage ShowIcon = new(new(ImageSource + "view-icon.png"));
        public static readonly BitmapImage StartIcon = new(new(ImageSource + "start-icon.png"));
        public static readonly BitmapImage StartIconFilled = new(new(ImageSource + "start-icon-filled.png"));
        public static readonly BitmapImage UncheckedIcon = new(new(ImageSource + "unchcked-icon.png"));
    }
}
