using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using QuestionVisualisation.UserControls.TopicDisplay;

namespace QuestionVisualisation
{
    public partial class QuizizzWindow : Window
    {
        // TODO: craete list of user controls with interface IWindowPage;
        private TopicDisplayUserControl displayer;

        // TODO: Add generic functions for 
        // * getting needed window page
        // * Setting current window page
        public static QuizizzWindow QuizzWindowInstance { get; private set; } = new ();

        public QuizizzWindow()
        {
            InitializeComponent();
            displayer = new (this);
            SetController(displayer);
            QuizzWindowInstance = this;
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
