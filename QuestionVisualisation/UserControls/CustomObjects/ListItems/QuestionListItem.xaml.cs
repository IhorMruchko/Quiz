using QuestionVisualisation.Dialogs;
using QuestionVisualisation.Extensions;
using QuestionVisualisation.Objects;
using QuestionVisualisation.UserControls.QuestionsDisplay;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.ListItems
{
    public partial class QuestionListItem : UserControl
    {
        public QuestionListItem(Question question)
        {
            Question = question;
            InitializeComponent();
            TitleDisplay.Content = Question.QuestionTitle;
        }

        public Question Question { get; set; } = new Question();

        public QuestionsDisplayUserControl Context { get; set; }

        public void EditIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var questionEditor = new EditQuestionDialog()
            {
                QuestionTitle = Question.QuestionTitle,
                QuestionAnswer = Question.Answer
            };

            var dialogResult = questionEditor.ShowDialog();
            if (dialogResult == true)
            {
                var questionTitle = questionEditor.QuestionTitle.Equals(string.Empty)
                    ? Question.QuestionTitle
                    : questionEditor.QuestionTitle;

                var answer = questionEditor.QuestionAnswer.Equals(string.Empty)
                    ? Question.Answer
                    : questionEditor.QuestionAnswer;

                Question.QuestionTitle = questionTitle;
                Question.Answer = answer;
            }
            TitleDisplay.Content = Question.QuestionTitle;
        }

        private void TextDisplay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EditIcon_MouseDown(sender, e);
        }

        private void DeleteIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {            
            var result = MessageBox.Show("Do you want to delete this item?", "Ensure deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Context.Remove(this);
            }
        }

        private void TitleDisplay_MouseEnter(object sender, MouseEventArgs e)
        {
            TitleDisplay.ChangeColors(Constants.Colors.Black, Constants.Colors.White);
        }

        private void TitleDisplay_MouseLeave(object sender, MouseEventArgs e)
        {
            TitleDisplay.ChangeColors(Constants.Colors.White, Constants.Colors.Black);
        }

        private void DeleteIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            DeleteIcon.ChangeColors(Constants.Colors.LightRed);
        }

        private void DeleteIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            DeleteIcon.ChangeColors(Constants.Colors.White);
        }
    }
}
