using Quiz.Standart.Objects;
using Quiz.Visual.Controllers.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quiz.Visual.Controllers.Complex;

public partial class QuestionControl : UserControl, IQuizControl
{
    public QuestionControl(TopicDisplay display, Question question)
    {
        InitializeComponent();
        TopicDisplay = display;
        Question = question;
        TitleDisplayer.Content = Question.Title;
    }

    public TopicDisplay TopicDisplay { get; set; }

    public Question Question { get; set; }

    public QuizComponent QuizComponent => Question;

    private void DeleteButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        TopicDisplay.Remove(this);
    }
}
