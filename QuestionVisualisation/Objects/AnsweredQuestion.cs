namespace QuestionVisualisation.Objects
{
    public class AnsweredQuestion
    {
        public Question Question { get; set; } = new ();

        public bool IsCorrectlyAnswered { get; set; }
    }
}
