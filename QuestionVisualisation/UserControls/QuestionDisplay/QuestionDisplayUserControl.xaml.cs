using Microsoft.Win32;
using QuestionVisualisation.Objects;
using QuestionVisualisation.Services;
using QuestionVisualisation.Services.IOServices;
using QuestionVisualisation.UserControls.QuestionDisplay.KeyPressedEventHandlers;
using QuestionVisualisation.UserControls.QuestionDisplay.States;
using System.Linq;
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
            ChangeState(new ReadFromFile());
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

        public void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Title = "Open question files",
                Filter = "Text (*.txt)|*.txt;",
            };

            if (openFileDialog.ShowDialog() == true)
            {
                QuestionManager = new RandomizerService();
                QuestionManager.LoadedQuesions = IOService.ReadFromFile<Question>(openFileDialog.FileName).ToList();
                ChangeState(QuestionManager.LoadedQuesions.Count == 0
                    ? new ReadFromFile()
                    : new QuestionIsShown());
            }
        }
    }
}
