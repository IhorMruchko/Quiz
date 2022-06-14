using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
