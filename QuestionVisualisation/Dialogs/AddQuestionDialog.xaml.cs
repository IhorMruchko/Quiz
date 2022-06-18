using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.Dialogs
{
    public partial class AddQuestionDialog : Window
    {
        public AddQuestionDialog()
        {
            InitializeComponent();
        }

        public string QuestionTitle
        {
            get => TitleTextBox.Text.Trim();
            set => TitleTextBox.Text = value;
        }

        public string QuestionAnswer
        {
            get => AnswerTextBox.Text.Trim();
            set => AnswerTextBox.Text = value;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DialogResult = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TitleTextBox.Focus();
        }

        private void TitleTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
    }
}
