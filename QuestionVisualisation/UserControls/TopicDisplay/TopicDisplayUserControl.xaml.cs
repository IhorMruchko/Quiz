using QuestionVisualisation.Dialogs;
using QuestionVisualisation.Objects;
using QuestionVisualisation.Services.IOServices;
using QuestionVisualisation.UserControls.CustomObjects.Buttons;
using QuestionVisualisation.UserControls.CustomObjects.ListItems;
using QuestionVisualisation.UserControls.QuestionDisplay;
using QuestionVisualisation.UserControls.QuestionDisplay.States;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace QuestionVisualisation.UserControls.TopicDisplay
{
    public partial class TopicDisplayUserControl : UserControl, IWindowPage
    {
        public TopicDisplayUserControl()
        {
            InitializeComponent();
            LoadTopics();
            TopicView.Content = _panel;
        }

        private IEnumerable<Topic> topics = Enumerable.Empty<Topic>();

        private readonly StackPanel _panel = new ();
        
        private IEnumerable<Topic> Topics => _panel.Children.Cast<TopicListItem>()
            .Select(x => new Topic() { Title = x.TitleDisplay.Content.ToString() ?? "Title", Questions = x.QuestionList });

        private void LoadTopics()
        {
            if (File.Exists(Constants.InitialDirectory))
            {
                topics = IOService.ReadFromFile<Topic>(Constants.InitialDirectory);
                DisplayTopics();
            }
            else
            {
                IOService.WriteToFile(Constants.InitialDirectory, topics);
            }
        }

        public void OnClose()
        {
            IOService.WriteToFile(Constants.InitialDirectory, Topics);
        }

        private void DisplayTopics()
        {
            foreach(var topic in topics)
            {
                _panel.Children.Add(new TopicListItem(topic.Title) { QuestionList = topic.Questions });
            }
        }

        internal void Remove(TopicListItem topicProviderUserControl)
        {
            _panel.Children.Remove(topicProviderUserControl);
        }

        private void StartButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var allQuestions = Topics.SelectMany(t => t.Questions);
            var configureQuizzDialog = new ConfigureQuizzDialog();
            if (allQuestions.Any() && configureQuizzDialog.ShowDialog() == true)
            {
                QuizizzWindow.SetController(new QuestionDisplayUserControl(allQuestions.Take(configureQuizzDialog.QuestionTakeAmount)));
            }
        }

        private void AddButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _panel.Children.Add(new TopicListItem("New topic"));
        }

        public void ConfigureWindowOnStart(QuizizzWindow window)
        {
            var addButton = new AddButton();
            var startButton = new StartButton();
            addButton.MouseDown += AddButton_MouseDown;
            startButton.MouseDown += StartButton_Click;
            window.LowerBar.Children.Add(addButton);
            window.LowerBar.Children.Add(startButton);
        }

        public void ConfigureWindowOnEnd(QuizizzWindow window)
        {
            window.LowerBar.Children.Clear();
        }
    }
}
