using QuestionVisualisation.Services;
using QuestionVisualisation.UserControls.QuestionDisplay.KeyPressedEventHandlers;
using QuestionVisualisation.UserControls.QuestionDisplay.States;
using QuestionVisualisation.UserControls.TopicDisplay;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.QuestionDisplay
{
    public partial class QuestionDisplayUserControl : UserControl, IStateContext
    {
        private QuestionDisplayUserControlState _state = new ReadFromFile();

        public QuestionDisplayUserControl()
        {
            InitializeComponent();
        }

        public RandomizerService QuestionManager { get; set; } = new();

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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            QuizizzWindow.SetController<TopicDisplayUserControl>();
        }
    }
}
