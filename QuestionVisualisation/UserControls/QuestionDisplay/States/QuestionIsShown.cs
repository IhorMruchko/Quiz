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
            var current = Context!.QuestionManager.Next();
            Context!.ShowAnswerButton.IsEnabled = true;
            Context!.WrongAnswerButton.IsEnabled = false;
            Context!.CorrectAnswerButton.IsEnabled = false;
            Context!.QuestionPlaceholder.Text = current.QuestionTitle;
            Context!.AnswerPlaceHolder.Text = string.Empty;
        }
    }
}