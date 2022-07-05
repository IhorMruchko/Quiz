using Quiz.Standart;
using Quiz.Standart.Objects;
using Quiz.Visual.Controllers.Complex;
using Quiz.Visual.Controllers.Dialogs;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Quiz.Visual.Controllers.Pages;

public partial class TopicDisplay : IWindowPage
{
    public TopicDisplay(Topic peek)
    {
        InitializeComponent();
        CurrentPeek = peek;
        DisplayContent();
    }

    public Topic CurrentPeek { get; set; }

    public void Remove(UIElement topicControl)
    {
        ElementsContainer.Children.Remove(topicControl);
        if (topicControl is IQuizControl qc)
        {
            CurrentPeek.Children.Remove(qc.QuizComponent);
        }
    }

    public void OnKeyDown(object sender, KeyEventArgs args)
    {
    }

    public void InitWindow(QuizWindow window)
    {
        window.AddTopicButton.Click += AddTopic;
        window.AddQuestionButton.Click += AddQuestion;
        window.StartQuizzButton.MouseDown += StartQuizz;
    }

    public void CloseWindow(QuizWindow window)
    {
        window.AddTopicButton.Click -= AddTopic;
        window.AddQuestionButton.Click -= AddQuestion;
        window.StartQuizzButton.MouseDown -= StartQuizz;
    }

    private void DisplayContent()
    {
        CurrentPeek.Children.ToList().ForEach(c => ElementsContainer.Children.Add(ControlBuilder.Craete(this, c)));
    }

    private void StartQuizz(object sender, MouseButtonEventArgs e)
    {
        var questions = CurrentPeek.Questions;
        var dialog = new ConfigureQuizDialog();
        if (questions.Any() && dialog.ShowDialog() == true)
        {
            QuizWindow.NextPage(new QuestionDisplay(questions, dialog.Durration, dialog.QuestionAmount));
        }
    }

    private void AddTopic(object sender, RoutedEventArgs args)
    {
        var addTopicDailog = new ConfigureTopicDialog()
        {
            Title = "Add new topic",
            Icon = WPFConstants.Images.AddIconFilled,
        };

        if (addTopicDailog.ShowDialog() == true)
        {
            var newTopic = new Topic() { Title = addTopicDailog.TopicTitle };
            ElementsContainer.Children.Add(new TopicControl(this, newTopic));
            CurrentPeek.Children.Add(newTopic);
        }
    }

    private void AddQuestion(object sender, RoutedEventArgs e)
    {
        var addQuestionDialog = new ConfigureQuestionDialog()
        {
            Title = "Add new question",
            Icon = WPFConstants.Images.AddIconFilled
        };

        if (addQuestionDialog.ShowDialog() == true)
        {
            ElementsContainer.Children.Add(new QuestionControl(this, addQuestionDialog.Question));
            CurrentPeek.Children.Add(addQuestionDialog.Question);
        }
    }
}
