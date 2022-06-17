namespace QuestionVisualisation.UserControls.QuestionDisplay.States
{
    public class AllQuestionAnswered : QuestionDisplayUserControlState
    {
        public override void MarkCorrect()
        {
        }

        public override void MarkWrong()
        {
        }

        public override void ShowResults()
        {
        }

        protected override void UpdateContext()
        {
            Context!.QuestionProgressDisplayer.CurrentAmount -= 1;
            Context!.AnswerPlaceHolder.Text = string.Empty;
            Context!.QuestionPlaceholder.Text = Context!.QuestionManager.Result;
            Context!.ChangeState(new ReadFromFile());
        }
    }
}