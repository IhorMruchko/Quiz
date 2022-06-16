using QuestionVisualisation.Extensions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Buttons
{
    public partial class StartButton : UserControl
    {
        public StartButton()
        {
            InitializeComponent();
        }

        private void StartPlaceholder_MouseEnter(object sender, MouseEventArgs e)
        {
            StartPlaceholder.ChangeColors(Constants.Colors.LightGreen);
        }

        private void StartPlaceholder_MouseLeave(object sender, MouseEventArgs e)
        {
            StartPlaceholder.ChangeColors(Constants.Colors.Transparent);
        }
    }
}
