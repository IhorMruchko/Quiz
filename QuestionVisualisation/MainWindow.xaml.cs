using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuestionVisualisation.UserControls.TopicDisplay;

namespace QuestionVisualisation
{
    public partial class QuizizzWindow : Window
    {
        private static List<UserControl> _windowPages = new ();

        public static QuizizzWindow QuizzWindowInstance { get; private set; } = new ();

        public QuizizzWindow()
        {
            InitializeComponent();
            QuizzWindowInstance = this;
            SetController<TopicDisplayUserControl>();
        }

        public static TControl? GetController<TControl>()
            where TControl : UserControl, new()
        {
            var result = _windowPages.FirstOrDefault(x => x.GetType() == typeof(TControl));
            return result as TControl;
        }

        public static TControl AddController<TControl>(Action<TControl>? controllerConfiguration = null)
            where TControl: UserControl, new()
        {
            var control = GetController<TControl>();
            if (control is not null)
            {
                _windowPages.Remove(control);
            }
            else
            {
                control = new TControl();
            }

            controllerConfiguration?.Invoke(control);
            _windowPages.Add(control);
            return control;
        }

        public static void SetController<TControl>(Action<TControl>? control = null)
            where TControl : UserControl, new()
        {

            QuizzWindowInstance.WindowContent.Content = AddController(control);
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // ((QuestionDisplayUserControl)WindowContent.Content).QuestionDisplay_KeyDown(sender, e);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GetController<TopicDisplayUserControl>()!.OnClose();
        }
    }
}
