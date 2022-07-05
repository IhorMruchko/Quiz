using Quiz.Standart.Extensions;
using System;
using System.Windows;
using System.Windows.Input;

namespace Quiz.Visual.Controllers.Dialogs;

public partial class ConfigureQuizDialog : Window
{
    public ConfigureQuizDialog()
    {
        InitializeComponent();
    }

    public TimeSpan Durration => new(
        HourInput.Text.ToInt(),
        MinutesInput.Text.ToInt(),
        SecondsInput.Text.ToInt());

    public int QuestionAmount => QuiestionAmountInput.Text.ToInt() == 0 
                                    ? int.MaxValue
                                    : QuiestionAmountInput.Text.ToInt();

    private bool TextValidator_TextValidation(Controls.TextValidator sender, TextCompositionEventArgs args)
    {
        return (sender.Text + args.Text).ToInt() <= 59;
    }

    private void CorrectButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DialogResult = true;
    }

    private void WrongButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DialogResult = false;
    }
}
