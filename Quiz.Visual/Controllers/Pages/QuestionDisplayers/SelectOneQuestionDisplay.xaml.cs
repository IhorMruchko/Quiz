using Quiz.Standart.Objects;
using Quiz.Standart.Objects.Questions;
using System.Linq;
using System.Windows.Controls;

namespace Quiz.Visual.Controllers.Pages.QuestionDisplayers;

public partial class SelectOneQuestionDisplay : UserControl, IQuestionRepresenter
{
    public SelectOneQuestionDisplay()
    {
        InitializeComponent();
    }

    public SelectOneQuestion? SelectOneQuestion { get; set; }

    public bool IsAnsweredCorrect 
        =>  AnswerList.Children.Cast<RadioButton>()
            .FirstOrDefault(r => r.IsChecked ?? false)?.Content.ToString() == SelectOneQuestion?.CorrectAnswer;

    public Question? Question 
    {
        get => SelectOneQuestion;
        set
        {
            SelectOneQuestion = value as SelectOneQuestion;
            value?.AnswerList.ForEach(a => AnswerList.Children.Add(new RadioButton() { Content = a }));
        }
    }
}
