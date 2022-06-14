using System.Windows;
using System.Windows.Input;

namespace QuestionVisualisation.Dialogs
{
    public partial class EditQuestionDialog : Window
    {
        public EditQuestionDialog()
        {
            InitializeComponent();
        }

        public string QuestionTitle 
        {
            get => TitleTextBox.Text;
            set => TitleTextBox.Text = value; 
        }

        public string QuestionAnswer
        {
            get => AnswerTextBox.Text;
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
    }
}
