using System.Windows;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.QuestionDisplay.KeyPressedEventHandlers
{
    public class OpenFileEventHandler : IKeyPressedOnQuestionDisplayControlEventHandler
    {
        public bool IsKeyPressed()
        {
            return Keyboard.IsKeyDown(Key.Up);
        }

        public void OnKeyPressed(QuestionDisplayUserControl window)
        {
            window.OpenButton_Click(window.OpenButton, new RoutedEventArgs());
        }
    }
}
