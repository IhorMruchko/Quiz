using System.Windows;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.QuestionDisplay.KeyPressedEventHandlers
{
    public class MarkWrongEventHandler : IKeyPressedOnQuestionDisplayControlEventHandler
    {
        public bool IsKeyPressed()
        {
            return Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.W);
        }

        public void OnKeyPressed(QuestionDisplayUserControl window)
        {
            window.WrongAnswerButton_Click(window.WrongAnswerButton, new RoutedEventArgs());
        }
    }
}
