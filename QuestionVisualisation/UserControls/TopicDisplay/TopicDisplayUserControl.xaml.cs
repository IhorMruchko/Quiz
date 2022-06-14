using QuestionVisualisation.Objects;
using QuestionVisualisation.Services.IOServices;
using QuestionVisualisation.UserControls.CustomObjects.ListItems;
using QuestionVisualisation.UserControls.QuestionDisplay;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace QuestionVisualisation.UserControls.TopicDisplay
{
    public partial class TopicDisplayUserControl : UserControl
    {
        public TopicDisplayUserControl(QuizizzWindow window)
        {
            InitializeComponent();
            WindowContext = window;
            LoadTopics();
        }

        private IEnumerable<Topic> topics = Enumerable.Empty<Topic>();

        private readonly StackPanel _panel = new ();

        public QuizizzWindow WindowContext { get; private set; }
        
        private IEnumerable<Topic> Topics => _panel.Children.Cast<TopicListItem>()
            .Select(x => new Topic() { Title = x.TitleDisplay.Content.ToString() ?? "Title", Questions = x.QuestionList });

        private void LoadTopics()
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, Constants.DataFileName);
            if (File.Exists(filePath))
            {
                topics = IOService.ReadFromFile<Topic>(filePath);
                DisplayTopics();
            }
            else
            {
                IOService.WriteToFile(filePath, topics);
            }
        }

        internal void OnClose()
        {
            IOService.WriteToFile(
                Path.Combine(Environment.CurrentDirectory, Constants.DataFileName),
                Topics);
        }

        private void DisplayTopics()
        {
            foreach(var topic in topics)
            {
                var button = new TopicListItem(this, topic.Title) { QuestionList = topic.Questions};
                _panel.Children.Add(button);
            }
            TopicView.Content = _panel;
        }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _panel.Children.Add(new TopicListItem(this, "New topic"));
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
                WindowContext.SetController(new QuestionDisplayUserControl(allQuestions, this, WindowContext));
            }
        }
    }
}
