using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Quiz.Standart.Objects
{
    public abstract class QuizComponent
    {
        public string Title { get; set; } = string.Empty;

        [IgnoreDataMember]
        public abstract IEnumerable<Question> Questions { get; }

        public virtual void Add(QuizComponent question)
        {

        }

        public virtual void Remove(QuizComponent question)
        {

        }

        public override string ToString()
        {
            return Title;
        }
    }
}