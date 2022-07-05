using System.Collections.Generic;

namespace Quiz.Standart.Objects.Questions
{
    public class SelectManyQuestion : Question
    {
        public List<string> CorrectAnswers { get; set; } = new List<string>();
    }
}