namespace QuestionVisualisation.UserControls.QuestionDisplay.States
{
    public class ReadFromFile : QuestionDisplayUserControlState
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
            Context!.ShowAnswerButton.IsEnabled = false;
            Context!.WrongAnswerButton.IsEnabled = false;
            Context!.CorrectAnswerButton.IsEnabled = false;
        }
    }
}
