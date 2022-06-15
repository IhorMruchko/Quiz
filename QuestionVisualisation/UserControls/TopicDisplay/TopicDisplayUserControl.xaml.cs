using QuestionVisualisation.Objects;
using QuestionVisualisation.Services.IOServices;
using QuestionVisualisation.UserControls.CustomObjects.ListItems;
using QuestionVisualisation.UserControls.QuestionDisplay;
using QuestionVisualisation.UserControls.QuestionDisplay.States;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace QuestionVisualisation.UserControls.TopicDisplay
{
    public partial class TopicDisplayUserControl : UserControl
    {
        public TopicDisplayUserControl()
        {
            InitializeComponent();
            LoadTopics();
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

        internal void OnClose()
        {
            IOService.WriteToFile(Constants.InitialDirectory, Topics);
        }

        private void DisplayTopics()
        {
            foreach(var topic in topics)
            {
                _panel.Children.Add(new TopicListItem(topic.Title) { QuestionList = topic.Questions });
            }
            TopicView.Content = _panel;
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _panel.Children.Add(new TopicListItem("New topic"));
            TopicView.Content = _panel;
        } 

        internal void Remove(TopicListItem topicProviderUserControl)
        {
            _panel.Children.Remove(topicProviderUserControl);
        }

        private void StartButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var allQuestions = Topics.SelectMany(t => t.Questions);
            if (allQuestions.Any())
            {
                QuizizzWindow.SetController<QuestionDisplayUserControl>(x =>
                {
                    x.QuestionManager.LoadedQuesions = allQuestions.ToList();
                    x.QuestionManager.Next(false);
                    x.ChangeState(new QuestionIsShown());
                });
            }
        }
    }
}
