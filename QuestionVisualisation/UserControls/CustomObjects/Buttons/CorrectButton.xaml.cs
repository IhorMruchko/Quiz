using QuestionVisualisation.Extensions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuestionVisualisation.UserControls.CustomObjects.Buttons
{
    public partial class CorrectButton : UserControl
    {
        public CorrectButton()
        {
            InitializeComponent();
        }

        private void CorrectPlacehoder_MouseEnter(object sender, MouseEventArgs e)
        {
            CorrectPlacehoder.ChangeColors(Constants.Colors.LightGreen);
        }

        private void CorrectPlacehoder_MouseLeave(object sender, MouseEventArgs e)
        {
            CorrectPlacehoder.ChangeColors(Constants.Colors.Transparent);
        }
    }
}
