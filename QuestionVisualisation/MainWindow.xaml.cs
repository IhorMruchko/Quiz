using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuestionVisualisation.UserControls;
using QuestionVisualisation.UserControls.TopicDisplay;

namespace QuestionVisualisation
{
    public partial class QuizizzWindow : Window
    {
        public static Stack<UserControl> OppenedPagesHistory { get; private set; } = new ();
        
        private static UserControl CurrentUserControl { get; set; } = new TopicDisplayUserControl();

        public static QuizizzWindow QuizzWindowInstance { get; private set; } = new ();

        public QuizizzWindow()
        {
            InitializeComponent();
            QuizzWindowInstance = this;
            SetController(CurrentUserControl);
        }

        public static TContol? GetController<TContol>()
            where TContol : UserControl, new()
        {
            return OppenedPagesHistory.LastOrDefault(x => x.GetType() == typeof(TContol)) as TContol;
        }

        public static void SetController(UserControl controller)
        {
            OppenedPagesHistory.Push(CurrentUserControl);
            ((IWindowPage)CurrentUserControl).ConfigureWindowOnEnd(QuizzWindowInstance);
            CurrentUserControl = controller;
            ((IWindowPage)controller).ConfigureWindowOnStart(QuizzWindowInstance);
            QuizzWindowInstance.WindowContent.Content = CurrentUserControl;
        }


        // TODO: implement keydown event for pages
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // ((QuestionDisplayUserControl)WindowContent.Content).QuestionDisplay_KeyDown(sender, e);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GetController<TopicDisplayUserControl>()?.OnClose();
        }

        public void BackButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (OppenedPagesHistory.Peek().GetType() == typeof(TopicDisplayUserControl) && OppenedPagesHistory.Count <= 1)
            {
                return;
            }
            var content = OppenedPagesHistory.Pop();
            ((IWindowPage)CurrentUserControl).ConfigureWindowOnEnd(QuizzWindowInstance);
            CurrentUserControl = content;
            ((IWindowPage)CurrentUserControl).ConfigureWindowOnStart(QuizzWindowInstance);
            QuizzWindowInstance.WindowContent.Content = CurrentUserControl;
        }

        private void SaveButton_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GetController<TopicDisplayUserControl>()?.OnClose();
        }
    }
}
