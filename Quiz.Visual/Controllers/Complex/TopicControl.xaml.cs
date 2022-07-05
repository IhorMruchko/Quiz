using Quiz.Standart;
using Quiz.Standart.Objects;
using Quiz.Visual.Controllers.Dialogs;
using Quiz.Visual.Controllers.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quiz.Visual.Controllers.Complex;

public partial class TopicControl : UserControl, IQuizControl
{
    public TopicControl(TopicDisplay display, Topic currentTopic)
    {
        InitializeComponent();
        TopicDisplay = display;
        CurrentTopic = currentTopic;
        TitleDisplayer.Content = CurrentTopic.Title;
    }

    public TopicDisplay TopicDisplay { get; set; }

    public Topic CurrentTopic { get; set; }
    
    public QuizComponent QuizComponent => CurrentTopic;

    private void EditButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var editTitle = new ConfigureTopicDialog 
        {
            Title = $"Edit topic {CurrentTopic.Title}",
            Icon = WPFConstants.Images.EditIconFilled,
            TopicTitle = CurrentTopic.Title,
        };

        if (editTitle.ShowDialog() == true)
        {
            CurrentTopic.Title = editTitle.TopicTitle.Equals(string.Empty)
                ? CurrentTopic.Title
                : editTitle.TopicTitle;
            TitleDisplayer.Content = CurrentTopic.Title;
        }
    }

    private void DeleteButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TopicDisplay.Remove(this);
    }

    private void TitleDisplayer_MouseDown(object sender, MouseButtonEventArgs e)
    {
        QuizWindow.Quiz?.OpenedPages.NextPage(new TopicDisplay(CurrentTopic));
    }
}
