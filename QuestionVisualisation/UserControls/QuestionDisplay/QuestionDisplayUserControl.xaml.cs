using QuestionVisualisation.Objects;
using QuestionVisualisation.Services;
using QuestionVisualisation.UserControls.CustomObjects.Buttons;
using QuestionVisualisation.UserControls.CustomObjects.Displayers;
using QuestionVisualisation.UserControls.QuestionDisplay.KeyPressedEventHandlers;
using QuestionVisualisation.UserControls.QuestionDisplay.States;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.QuestionDisplay
{
    public partial class QuestionDisplayUserControl : UserControl, IWindowPage
    {
        private QuestionDisplayUserControlState _state = new ReadFromFile();

        public QuestionProgressDisplayer QuestionProgressDisplayer { get; set;} = new QuestionProgressDisplayer() { CurrentAmount = 1 };

        public RandomizerService QuestionManager { get; set; } = new();

        public QuestionDisplayUserControl(IEnumerable<Question> questions)
        {
            InitializeComponent();
            QuestionManager.LoadedQuesions = questions.ToList();
            QuestionManager.Next(false);
            ChangeState(new QuestionIsShown());
        }

        public void ChangeState(QuestionDisplayUserControlState newState)
        {
            _state = newState;
            _state.SetWindow(this);
        }

        public void QuestionDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            var hanlder = KeyPressedEventHandlerFactory.GetProperHandler();
            hanlder?.OnKeyPressed(this);
        }

        public void WrongAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            _state.MarkWrong();
        }

        public void CorrectAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            _state.MarkCorrect();
        }

        public void ShowAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            _state.ShowResults();
        }

        public void ConfigureWindowOnStart(QuizizzWindow window)
        {
            var backButton = new BackButton();
            var wrongButton = new WrongButton();
            var showButton = new ShowButton();
            var correctButton = new CorrectButton();
            QuestionProgressDisplayer.TotalAmount = QuestionManager.LoadedQuesions.Count;
            backButton.MouseDown += window.BackButton_MouseDown;
            wrongButton.MouseDown += WrongAnswerButton_Click;
            showButton.MouseDown += ShowAnswerButton_Click;
            correctButton.MouseDown += CorrectAnswerButton_Click;
            window.LowerBar.Children.Add(backButton);
            window.LowerBar.Children.Add(wrongButton);
            window.LowerBar.Children.Add(showButton);
            window.LowerBar.Children.Add(correctButton);
            Grid.SetColumn(QuestionProgressDisplayer, 2);
            window.ButtonsGrid.Children.Add(QuestionProgressDisplayer);
        }

        public void ConfigureWindowOnEnd(QuizizzWindow window)
        {
            window.LowerBar.Children.Clear();
            window.ButtonsGrid.Children.RemoveAt(window.ButtonsGrid.Children.Count - 1);
        }
    }
}
