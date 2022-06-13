namespace QuestionVisualisation.UserControls.QuestionDisplay.States
{
    public abstract class QuestionDisplayUserControlState
    {
        protected QuestionDisplayUserControl? Context { get; set; }

        public abstract void MarkWrong();

        public abstract void MarkCorrect();

        public abstract void ShowResults();

        protected abstract void UpdateContext();

        public virtual void SetWindow(QuestionDisplayUserControl questionDisplay)
        {
            Context = questionDisplay;
            UpdateContext();
        }
    }
}