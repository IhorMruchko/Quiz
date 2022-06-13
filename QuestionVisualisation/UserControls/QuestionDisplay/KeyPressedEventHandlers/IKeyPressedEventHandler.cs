namespace QuestionVisualisation.UserControls.QuestionDisplay.KeyPressedEventHandlers
{
    public interface IKeyPressedOnQuestionDisplayControlEventHandler
    {
        public bool IsKeyPressed();

        public void OnKeyPressed(QuestionDisplayUserControl window);
    }
}
