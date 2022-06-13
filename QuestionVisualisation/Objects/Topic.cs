using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionVisualisation.Objects
{
    [Serializable]
    public class Topic
    {
        public string Title { get; set; } = string.Empty;

        public IEnumerable<Question> Questions { get; set; } = Enumerable.Empty<Question>();
    }
}
