using Quiz.Standart.Objects;
using Quiz.Standart.Objects.Questions;
using System.Linq;
using System.Windows.Controls;

namespace Quiz.Visual.Controllers.Pages.QuestionDisplayers;

public partial class SelectManyQuestionDisplay : UserControl, IQuestionRepresenter
{
    public SelectManyQuestionDisplay()
    {
        InitializeComponent();
    }

    public SelectManyQuestion? SelectManyQuestion { get; set; }

    public Question? Question
    {
        get => SelectManyQuestion;
        set
        {
            SelectManyQuestion = value as SelectManyQuestion;
            value?.AnswerList.ForEach(a => AnswerList.Children.Add(new CheckBox() { Content = a }));
        }
    }

    public bool IsAnsweredCorrect =>
        AnswerList.Children.Cast<CheckBox>()
                  .Where(x => x.IsChecked ?? false)
                  .Select(x => x.Content.ToString())
                  .Except(SelectManyQuestion!.CorrectAnswers)
                  .Any() == false;
}

