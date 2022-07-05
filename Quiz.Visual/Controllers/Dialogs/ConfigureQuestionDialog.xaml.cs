using Quiz.Standart.Objects;
using Quiz.Standart.Objects.Questions;
using Quiz.Visual.Controllers.Controls;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Quiz.Visual.Controllers.Dialogs;

public partial class ConfigureQuestionDialog : Window
{
    public ConfigureQuestionDialog()
    {
        InitializeComponent();
        TitleInput.Focus();
    }

    public Question Question { get; private set; } = new SelectOneQuestion();
    
    private void ConfirmResult()
    {
        if (SubmitQuestion())
        {
            DialogResult = true;
        }
    }

    private bool SubmitQuestion()
    {
        var answers = AnswerContainer.Children.Cast<AnswerView>().ToList();
        
        var selectedAmount = answers.Count(a => a.IsSelected);
        if (selectedAmount == 0)
        {
            MessageBox.Show("Select at least one answer");
            return false;
        }

        if (selectedAmount == 1)
        {
            Question = new SelectOneQuestion()
            {
                Title = TitleInput.Text,
                AnswerList = answers.Select(a => a.TitleInput.Text).ToList(),
                CorrectAnswer = answers.First(a => a.IsSelected).TitleInput.Text,
            };
        }

        if (selectedAmount > 1)
        {
            Question = new SelectManyQuestion()
            {
                Title = TitleInput.Text,
                AnswerList = answers.Select(a => a.TitleInput.Text).ToList(),
                CorrectAnswers = answers.Where(a => a.IsSelected).Select(a => a.TitleInput.Text).ToList()
            };
        }

        return true;
    }

    private void HoverableButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        AnswerContainer.Children.Add(new AnswerView(this));
    }

    private void CorrectButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        ConfirmResult();
    }

    private void WrongButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DialogResult = false;
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            ConfirmResult();
        }
    }
}
