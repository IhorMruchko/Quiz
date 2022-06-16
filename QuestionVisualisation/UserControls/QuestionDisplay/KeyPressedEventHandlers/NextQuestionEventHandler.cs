using System.Windows;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.QuestionDisplay.KeyPressedEventHandlers
{
    public class NextQuestionEventHandler : IKeyPressedOnQuestionDisplayControlEventHandler
    {
        public bool IsKeyPressed()
        {
            return Keyboard.IsKeyDown(Key.Space);
        }

        public void OnKeyPressed(QuestionDisplayUserControl window)
        {
            
        }
    }
}
