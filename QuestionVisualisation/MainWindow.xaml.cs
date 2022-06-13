using System.Windows;
using System.Windows.Controls;
using QuestionVisualisation.UserControls.TopicDisplay;

namespace QuestionVisualisation
{
    public partial class QuizizzWindow : Window
    {
        private TopicDisplayUserControl displayer;
        public QuizizzWindow()
        {
            InitializeComponent();
            //TODO: Add more content pages
            // * View topic page
            // * Manage question page
            // * Quizz page
            displayer = new TopicDisplayUserControl(this);
            SetController(displayer);
        }

        public void SetController(UserControl controller)
        {
            WindowContent.Content = controller;
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // ((QuestionDisplayUserControl)WindowContent.Content).QuestionDisplay_KeyDown(sender, e);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            displayer.OnClose();
        }
    }
}
