using Microsoft.Win32;
using QuestionVisualisation.Dialogs;
using QuestionVisualisation.Objects;
using QuestionVisualisation.Services.IOServices;
using QuestionVisualisation.UserControls.CustomObjects.Buttons;
using QuestionVisualisation.UserControls.CustomObjects.ListItems;
using QuestionVisualisation.UserControls.QuestionDisplay;
using QuestionVisualisation.UserControls.TopicDisplay;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.QuestionsDisplay
{
    public partial class QuestionsDisplayUserControl : UserControl, IWindowPage
    {
        public TopicListItem? Context { get; set; }

        private readonly StackPanel panel = new ();

        public QuestionsDisplayUserControl(TopicListItem context)
        {
            InitializeComponent();
            Context = context;
            DisplayQuestions();
        }

        public void DisplayQuestions()
        {
            foreach (var q in Context!.QuestionList)
            {
                panel.Children.Add(new QuestionListItem(this, q) { Context = this});
            }
            QuestionView.Content = panel;
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
                
                panel.Children.Add(new QuestionListItem(this, question));
                Context!.QuestionList.Add(question);
            }
            
        }

        private void StartTest(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Context!.QuestionList.Count == 0)
            {
                return;
            }

            QuizizzWindow.SetController(new QuestionDisplayUserControl(Context!.QuestionList));
        }

        public void ConfigureWindowOnStart(QuizizzWindow window)
        {
            var backButton = new BackButton();
            var addButton = new AddButton();
            var startButton = new StartButton();
            var downloadButton = new DownloadButton();
            backButton.MouseDown += window.BackButton_MouseDown;
            addButton.MouseDown += Add_Click;
            startButton.MouseDown += StartTest;
            downloadButton.MouseDown += DownloadAllData;
            window.LowerBar.Children.Add(backButton);
            window.LowerBar.Children.Add(addButton);
            window.LowerBar.Children.Add(startButton);
            window.LowerBar.Children.Add(downloadButton);
        }

        private void DownloadAllData(object sender, MouseButtonEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "All|*.txt;*.xml;*.json|Text|*.txt|Json|*.json|Xml|*.xml"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                AddQuestions(IOService.ReadFromFile<Question>(openFileDialog.FileName));
            }
        }

        private void AddQuestions(IEnumerable<Question> questions)
        {
            foreach(var question in questions)
            {
                panel.Children.Add(new QuestionListItem(this, question));
                Context!.QuestionList.Add(question);
            }
        }

        public void ConfigureWindowOnEnd(QuizizzWindow window)
        {
            window.LowerBar.Children.Clear();
        }
    }
}

