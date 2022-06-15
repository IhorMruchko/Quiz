using QuestionVisualisation.Dialogs;
using QuestionVisualisation.Objects;
using QuestionVisualisation.UserControls.CustomObjects.ListItems;
using QuestionVisualisation.UserControls.QuestionDisplay;
using QuestionVisualisation.UserControls.TopicDisplay;
using System.Windows.Controls;

namespace QuestionVisualisation.UserControls.QuestionsDisplay
{
    public partial class QuestionsDisplayUserControl : UserControl
    {
        public TopicListItem? Context { get; set; }

        private readonly StackPanel panel = new ();

        public QuestionsDisplayUserControl()
        {
            InitializeComponent();
        }

        public void DisplayQuestions()
        {
            foreach (var q in Context!.QuestionList)
            {
                panel.Children.Add(new QuestionListItem(q) { Context = this});
            }
            QuestionView.Content = panel;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            panel.Children.Clear();
            QuizizzWindow.SetController<TopicDisplayUserControl>();
        }


        internal void Remove(QuestionListItem questionListItem)
        {
            panel.Children.Remove(questionListItem);
            Context!.QuestionList.Remove(questionListItem.Question);
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var addQuestionDialog = new AddQuestionDialog();
            if (addQuestionDialog.ShowDialog() == true)
            {
                var question = new Question()
                {
                    QuestionTitle = addQuestionDialog.QuestionTitle,
                    Answer = addQuestionDialog.QuestionAnswer
                };
                
                panel.Children.Add(new QuestionListItem(question));
                Context!.QuestionList.Add(question);
            }
            
        }

        private void StartTest(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Context!.QuestionList.Count == 0)
            {
                return;
            }

            QuizizzWindow.SetController<QuestionDisplayUserControl>();
        }
    }
}

