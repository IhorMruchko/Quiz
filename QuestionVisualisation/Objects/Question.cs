using System;

namespace QuestionVisualisation.Objects
{
    [Serializable]
    public class Question
    {
        public string QuestionTitle { get; set; } = string.Empty;

        public string Answer { get; set; } = string.Empty;

        // TODO: move this prop to another object;
        public bool IsCorrectAnswered { get; set; } = false;
        
        public override string ToString()
        {
            return $"{QuestionTitle} {Answer}";
        }
    }
}
