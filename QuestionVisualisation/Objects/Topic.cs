using System.Collections.Generic;

namespace QuestionVisualisation.Objects
{
    public class Topic
    {
        public string Title { get; set; } = string.Empty;

        public List<Question> Questions { get; set; } = new ();
    }
}
