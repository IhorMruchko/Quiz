using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QuestionVisualisation.Extensions;
using QuestionVisualisation.Objects;
using QuestionVisualisation.Services;
using QuestionVisualisation.UserControls.QuestionsDisplay;
using QuestionVisualisation.UserControls.TopicDisplay;

namespace QuestionVisualisation.UserControls
{
    public partial class TopicProviderUserControl : UserControl
    {
        public IEnumerable<Question> QuestionList { get; internal set; } = Enumerable.Empty<Question>();
        
        public TopicDisplayUserControl Context { get; protected set; }
       
        public TopicProviderUserControl(TopicDisplayUserControl context, string title)
        {
            InitializeComponent();
            Context = context;  
            TitleDisplay.Content = title;
        }

        private void TextDisplay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Context.WindowContext.SetController(new QuestionsDisplayUserControl(Context, QuestionList));
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
        }

        private void TitleChanger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ChangeTitle();
            }
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
            TitleDisplay.ChangeColors(Constants.BlackColor, Constants.White);
        }

        private void TitleDisplay_MouseLeave(object sender, MouseEventArgs e)
        {
            TitleDisplay.ChangeColors(Constants.White, Constants.BlackColor);
        }
    }
}
