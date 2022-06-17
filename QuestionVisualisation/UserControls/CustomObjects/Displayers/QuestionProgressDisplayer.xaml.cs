using QuestionVisualisation.Extensions;
using System.Windows.Controls;

namespace QuestionVisualisation.UserControls.CustomObjects.Displayers
{
    public partial class QuestionProgressDisplayer : UserControl
    {
        public QuestionProgressDisplayer()
        {
            InitializeComponent();
        }

        public int TotalAmount 
        {
            get => (AllQuestionsAmount.Content.ToString()?? "0").ToInt();
            set => AllQuestionsAmount.Content = value;
        }

        public int CurrentAmount
        {
            get => (CurrentShownQuestionsAmount.Content.ToString() ?? "0").ToInt();
            set => CurrentShownQuestionsAmount.Content = value;
        }
    }
}
