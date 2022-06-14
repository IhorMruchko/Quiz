using QuestionVisualisation.UserControls.CustomObjects.ListItems;
using QuestionVisualisation.UserControls.TopicDisplay;
using System.Collections.Generic;
using System.Windows.Controls;

namespace QuestionVisualisation.UserControls.QuestionsDisplay
{
    public partial class QuestionsDisplayUserControl : UserControl
    {
        public TopicListItem Context { get; }

        private readonly TopicDisplayUserControl _topic;

        private readonly StackPanel panel = new ();

        public QuestionsDisplayUserControl(TopicListItem topicReturnTo)
        {
            InitializeComponent();
            Context = topicReturnTo;
            _topic = topicReturnTo.Context;
            DisplayQuestions();
        }

        private void DisplayQuestions()
        {
            foreach (var q in Context.QuestionList)
            {
                panel.Children.Add(new QuestionListItem(this, q));
            }
            QuestionView.Content = panel;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _topic.WindowContext.SetController(_topic);
        }


        internal void Remove(QuestionListItem questionListItem)
        {
            panel.Children.Remove(questionListItem);
            Context.QuestionList.Remove(questionListItem.Question);
        }
    }
}

