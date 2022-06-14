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
        public QuestionListItem(QuestionsDisplayUserControl context, Question question)
        {
            InitializeComponent();
            Context = context;
            Question = question;
            TitleDisplay.Content = Question.QuestionTitle;
        }

        public Question Question { get; set; }

        public QuestionsDisplayUserControl Context { get; set; }

        private void TextDisplay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                
            }
        }

        private void TitleChanger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChangeTitle();
            }
        }

        private void TitleChanger_LostFocus(object sender, RoutedEventArgs e)
        {
            ChangeTitle();
        }

        private void ChangeTitle()
        {
            TitleDisplay.Content = TitleChanger.Text ?? TitleDisplay.Content;
            TitleChanger.Visibility = Visibility.Hidden;
            Question.QuestionTitle = TitleDisplay.Content.ToString() ?? "Title";
        }


        private void EditIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TitleChanger.Visibility = Visibility.Visible;
            TitleChanger.Text = TitleDisplay.Content.ToString();
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

        private void EditIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            EditIcon.ChangeColors(Constants.Colors.Purple);
        }

        private void EditIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            EditIcon.ChangeColors(Constants.Colors.White);
        }
    }
}
