using System;
using System.Windows;
using System.Windows.Input;

namespace QuestionVisualisation.Dialogs
{
    public partial class ConfigureQuizzDialog : Window
    {
        public ConfigureQuizzDialog()
        {
            InitializeComponent();
        }

        public int QuestionTakeAmount
            => QuestionAmountInput.Value <= 0 ? int.MaxValue : QuestionAmountInput.Value;

        public TimeSpan Time => new (Hours.Value, Minutes.Value, Seconds.Value);

        private void CorrectButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DialogResult = true;
        }

        private void WrongButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QuestionAmountInput.TextContainer.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DialogResult = true;
            }
        }
    }
}
