using QuestionVisualisation.Objects;
using QuestionVisualisation.UserControls.TopicDisplay;
using System.Collections.Generic;
using System.Windows.Controls;

namespace QuestionVisualisation.UserControls.QuestionsDisplay
{
    public partial class QuestionsDisplayUserControl : UserControl
    {
        private readonly TopicDisplayUserControl _topic;

        private readonly IEnumerable<Question> _questions;

        public QuestionsDisplayUserControl(TopicDisplayUserControl topicReturnTo, IEnumerable<Question> questionsToDisplay)
        {
            InitializeComponent();
            _topic = topicReturnTo;
            _questions = questionsToDisplay;
            DisplayQuestions();
        }

        private void DisplayQuestions()
        {
            var stackPanel = new StackPanel();
            foreach (var q in _questions)
            {
                stackPanel.Children.Add(new Button() { Content = $"{q.QuestionTitle} - {q.Answer}" });
            }
            QuestionView.Content = stackPanel;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _topic.WindowContext.SetController(_topic);
        }
    }
}

