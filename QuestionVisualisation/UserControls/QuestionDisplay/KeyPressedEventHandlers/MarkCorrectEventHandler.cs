using System.Windows;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.QuestionDisplay.KeyPressedEventHandlers
{
    public class MarkCorrectEventHandler : IKeyPressedOnQuestionDisplayControlEventHandler
    {
        public bool IsKeyPressed()
        {
            return Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.C);
        }

        public void OnKeyPressed(QuestionDisplayUserControl window)
        {
            
        }
    }
}
