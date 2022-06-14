using QuestionVisualisation.Dialogs;
using QuestionVisualisation.Objects;
using QuestionVisualisation.Services;
using QuestionVisualisation.UserControls.CustomObjects.ListItems;
using QuestionVisualisation.UserControls.QuestionDisplay;
using QuestionVisualisation.UserControls.TopicDisplay;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

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
                
                panel.Children.Add(new QuestionListItem(this, question));
                Context.QuestionList.Add(question);
            }
            
        }

        private void StartTest(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Context.QuestionList.Count == 0)
            {
                return;
            }
            Context.Context.WindowContext.SetController(new QuestionDisplayUserControl(Context.QuestionList, this, Context.Context.WindowContext));
        }
    }
}

