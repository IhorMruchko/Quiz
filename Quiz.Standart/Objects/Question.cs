using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Quiz.Standart.Objects
{
    public abstract class Question : QuizComponent
    {
        [IgnoreDataMember]
        public override IEnumerable<Question> Questions => new List<Question>() { this };

        public List<string> AnswerList { get; set; } = new List<string>();
    }
}