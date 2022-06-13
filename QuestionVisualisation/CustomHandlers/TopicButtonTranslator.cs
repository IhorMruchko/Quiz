using QuestionVisualisation.Objects;
using System.Collections.Generic;
using System.Windows.Controls;

namespace QuestionVisualisation.CustomHandlers
{
    public class TopicButtonTranslator : Button
    {
        public IEnumerable<Question> QuestionList { get; set; } = new List<Question>();
    }
}
