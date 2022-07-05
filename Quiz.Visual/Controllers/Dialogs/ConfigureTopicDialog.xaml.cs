using System.Windows;
using System.Windows.Input;

namespace Quiz.Visual.Controllers.Dialogs;

public partial class ConfigureTopicDialog : Window
{
    public ConfigureTopicDialog()
    {
        InitializeComponent();
    }

    public string TopicTitle
    {
        get => TitleTextBox.Text.Trim();
        set => TitleTextBox.Text = value.Trim();
    }

    private void CorrectButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DialogResult = true;
    }

    private void WrongButton_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DialogResult = false;
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            DialogResult = true;
        }
    }
}
