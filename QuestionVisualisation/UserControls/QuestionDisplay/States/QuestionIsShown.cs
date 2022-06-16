namespace QuestionVisualisation.UserControls.QuestionDisplay.States
{
    public class QuestionIsShown : QuestionDisplayUserControlState
    {
        public override void MarkCorrect()
        {
        }

        public override void MarkWrong()
        {

        }

        public override void ShowResults()
        {
            Context!.AnswerPlaceHolder.Text = Context.QuestionManager.SelectedQuestion!.Answer;
            Context.ChangeState(new AnswerIsShown());
        }

        protected override void UpdateContext()
        {
            Context!.QuestionPlaceholder.Text = Context!.QuestionManager.SelectedQuestion!.QuestionTitle;
            Context!.AnswerPlaceHolder.Text = string.Empty;
        }
    }
}