using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Quiz.Standart.Objects
{
    public class Topic : QuizComponent
    {
        public ObservableCollection<QuizComponent> Children { get; set; } = new ObservableCollection<QuizComponent>();

        [IgnoreDataMember]
        public override IEnumerable<Question> Questions => Children.SelectMany(x => x.Questions);

        public override void Add(QuizComponent question)
        {
            Children.Add(question);
        }

        public override void Remove(QuizComponent question)
        {
            Children.Remove(question);
        }
    }
}