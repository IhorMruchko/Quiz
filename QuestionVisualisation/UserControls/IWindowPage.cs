namespace QuestionVisualisation.UserControls
{
    public interface IWindowPage
    {
        public void ConfigureWindowOnStart(QuizizzWindow window);

        public void ConfigureWindowOnEnd(QuizizzWindow window);
    }
}
