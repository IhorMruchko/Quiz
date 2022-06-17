namespace QuestionVisualisation.UserControls.QuestionDisplay.States
{
    public class AnswerIsShown : QuestionDisplayUserControlState
    {
        public override void MarkCorrect()
        {
            Mark(true);
        }

        public override void MarkWrong()
        {
            Mark(false);
        }

        public override void ShowResults()
        {
        }

        protected override void UpdateContext()
        {
        }

        private void Mark(bool value)
        {
            Context!.QuestionManager.Next(value);
            Context!.AnswerPlaceHolder.Text = string.Empty;
            Context!.ChangeState(
                Context!.QuestionManager.LoadedQuesions.Count == 0
                ? new AllQuestionAnswered()
                : new QuestionIsShown());
            Context!.QuestionProgressDisplayer.CurrentAmount += 1;
        }
    }
}