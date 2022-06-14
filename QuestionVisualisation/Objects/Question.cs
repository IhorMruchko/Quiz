namespace QuestionVisualisation.Objects
{
    public class Question
    {
        public string QuestionTitle { get; set; } = string.Empty;

        public string Answer { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{QuestionTitle} {Answer}";
        }
    }
}
